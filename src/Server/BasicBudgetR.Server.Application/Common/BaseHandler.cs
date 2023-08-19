

namespace BasicBudgetR.Server.Application.Common;
public abstract class BaseHandler<T>
{
    protected readonly BudgetRDbContext _context;
    protected readonly StateContainer _stateContainer;
    protected Result<T> Result;

    protected BaseHandler(BudgetRDbContext dbContext, StateContainer stateContainer)
    {
        _context = dbContext;
        _stateContainer =stateContainer;
        Result = new Result<T>();
    }

    protected async Task<long> CreateBta(bool addToContext = false)
    {
        var bta = new BusinessTransactionActivity
        {
            ProcessName = _stateContainer.ProcessName,
            UserId = _stateContainer.CurrentUserId.Value.Value,
            CreatedAt = DateTime.UtcNow
        };

        await _context.BusinessTransactionActivities.AddAsync(bta);
        await _context.SaveChangesAsync();

        if (addToContext)
        {
            _stateContainer.BtaId = bta.BusinessTransactionActivityId;
        }

        return bta.BusinessTransactionActivityId;
    }
}
