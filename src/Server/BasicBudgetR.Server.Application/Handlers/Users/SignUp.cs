using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasicBudgetR.Server.Application.Handlers.Users;
public class SignUp
{
    public record Request(string HouseholdName, string DisplayName) : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public Handler(BudgetRDbContext context, StateContainer stateContainer, IHttpContextAccessor httpContextAccessor)
            : base(context, stateContainer)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            string authId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            long BtaId = await CreateBta(true, "Users.SignUp");

            User user = new()
            {
                AuthId = authId,
                DisplayName = request.DisplayName,
                BtaId = BtaId,
            };

            Household household = new()
            {
                Name = request.HouseholdName,
                BusinessTransactionActivityId = BtaId,
                Users = new List<User> { user },
            };

            await _context.Households.AddAsync(household);
            await _context.SaveChangesAsync();

            await _context.AddRangeAsync(BuildMonthBudgetList(household.HouseholdId));
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        private List<MonthBudget> BuildMonthBudgetList(long HouseholdId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            List<MonthYear> monthYears = _context.MonthYears
                .Where(m => m.IsActive)
                .OrderBy(m => m.MonthYearId)
                .ToList();

            List<MonthBudget> monthBudgets = new();

            foreach (var monthYear in monthYears)
            {
                monthBudgets.Add(new MonthBudget
                {
                    MonthYearId = monthYear.MonthYearId,
                    HouseholdId = HouseholdId,
                });
            }

            return monthBudgets;
        }
    }
}