using BudgetR.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BudgetR.Server.Application.Handlers.Households;
public class CreateHousehold
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
                UserType = UserType.User,
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

            _stateContainer.UserId = user.UserId;
            _stateContainer.HouseholdId = user.HouseholdId;

            await _context.AddRangeAsync(BuildMonthBudgetList(household.HouseholdId));
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        private List<BudgetMonth> BuildMonthBudgetList(long HouseholdId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            List<MonthYear> monthYears = _context.MonthYears
                .Where(m => m.IsActive)
                .OrderBy(m => m.MonthYearId)
                .ToList();

            List<BudgetMonth> monthBudgets = new();

            foreach (var monthYear in monthYears)
            {
                monthBudgets.Add(new BudgetMonth
                {
                    MonthYearId = monthYear.MonthYearId,
                    HouseholdId = HouseholdId,
                });
            }

            return monthBudgets;
        }
    }
}