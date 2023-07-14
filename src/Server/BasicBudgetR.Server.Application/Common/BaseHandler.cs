namespace BasicBudgetR.Server.Application.Common;
public abstract class BaseHandler
{
    protected readonly IdentityDbContext _context;
    protected readonly CurrentProcess _currentProcess;

    protected BaseHandler(IdentityDbContext dbContext, CurrentProcess currentProcess)
    {
        _context = dbContext;
        _currentProcess = currentProcess;
    }
}
