namespace BasicBudgetR.Server.Application.Common;
public abstract class BaseHandler
{
    protected readonly BudgetRDbContext _context;
    protected readonly CurrentProcess _currentProcess;

    protected BaseHandler(BudgetRDbContext dbContext, CurrentProcess currentProcess)
    {
        _context = dbContext;
        _currentProcess = currentProcess;
    }

    protected async Task<long> CreateBta(bool addToContext = false)
    {
        var bta = new BusinessTransactionActivity
        {
            ProcessName = _currentProcess.ProcessName,
            UserDetailId = _currentProcess.CurrentUserDetailId,
            CreatedAt = DateTime.UtcNow
        };

        await _context.BusinessTransactionActivities.AddAsync(bta);
        await _context.SaveChangesAsync();

        if (addToContext)
        {
            _currentProcess.BtaId = bta.BusinessTransactionActivityId;
        }

        return bta.BusinessTransactionActivityId;
    }
}
