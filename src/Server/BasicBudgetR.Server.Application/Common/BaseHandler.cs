namespace BasicBudgetR.Server.Application.Common;
public abstract class BaseHandler
{
    protected readonly ApplicationDbContext _context;
    protected readonly CurrentProcess _currentProcess;

    protected BaseHandler(ApplicationDbContext dbContext, CurrentProcess currentProcess)
    {
        _context = dbContext;
        _currentProcess = currentProcess;
    }
}
