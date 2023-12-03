using BudgetR.Core.Enums;
using BudgetR.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace BudgetR.Server.Application.Handlers.Users;
public class CreateHousehold
{
    public record Request(string HouseholdName, string FirstName, string LastName) : IRequest<Result<NoValue>>;

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1);
            RuleFor(x => x.HouseholdName)
                .NotNull()
                .MinimumLength(3);
        }
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        private readonly Validator _validator = new();

        private readonly UserManager<ApplicationUser> _userManager;
        public Handler(BudgetRDbContext context, StateContainer stateContainer, UserManager<ApplicationUser> userManager)
            : base(context, stateContainer)
        {
            _userManager = userManager;
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                return Result.Error(validation.Errors);
            }

            string authenticationId = _stateContainer.ApplicationUserId;

            long BtaId = await CreateBta();

            User user = new()
            {
                AuthenticationId = authenticationId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserType = UserType.User,
                IsActive = true,
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