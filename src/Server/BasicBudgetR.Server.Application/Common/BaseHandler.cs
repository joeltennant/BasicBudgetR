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
}
