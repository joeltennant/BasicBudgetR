using BasicBudgetR.Core.Extensions;

namespace BasicBudgetR.Server.Application.Handlers.System;
public class InactivatePastMonths
{
    public record Request() : IRequest<Result<int>>;

    public class Handler : BaseHandler<int>, IRequestHandler<Request, Result<int>>
    {
        private BusinessTransactionActivity bta;

        public Handler(BudgetRDbContext context, StateContainer stateContainer)
            : base(context, stateContainer)
        {
        }

        public async Task<Result<int>> Handle(Request request, CancellationToken cancellationToken)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            IList<long> budgetMonthIds = new List<long>();

            var monthYears = await _context.MonthYears
                .Where(x => x.IsActive
                            && new DateOnly(x.Year, x.Month, x.NumberOfDays) < today)
                .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                .ToListAsync();

            if (monthYears.IsPopulated())
            {
                bta = new BusinessTransactionActivity
                {
                    ProcessName = "System.InactivatePastMonths",
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow
                };

                await _context.BusinessTransactionActivities.AddAsync(bta);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Result.Success();
            }

            foreach (var monthYear in monthYears)
            {
                monthYear.IsActive = false;
            }

            //get budget month ids that have a monthYear from the list above
            budgetMonthIds = await _context.BudgetMonths
                .Where(x => monthYears.Any(y => y.MonthYearId == x.MonthYearId))
                .Select(x => x.BudgetMonthId)
                .ToListAsync();

            //inactivate expense details that have a budget month id from the list above
            await _context.ExpenseDetails
                .Where(x => budgetMonthIds.Contains(x.BudgetMonthId))
                    .ExecuteUpdateAsync(a => a
                                .SetProperty(p => p.BusinessTransactionActivityId, bta.BusinessTransactionActivityId)
                                .SetProperty(p => p.IsActive, true));

            var monthsChanged = await _context.SaveChangesAsync();


            return Result.Success(monthsChanged);
        }
    }
}
