using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasicBudgetR.Server.Application.PipelineBehaviors;

public class PreRequestBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private CurrentProcess _currentProcess;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IdentityDbContext _identityContext;
    private readonly BudgetRDbContext _context;

    public PreRequestBehavior(CurrentProcess currentProcess
        , IHttpContextAccessor httpContextAccessor
        , IdentityDbContext identityContext
        , BudgetRDbContext context)
    {
        _currentProcess = currentProcess;
        _httpContextAccessor = httpContextAccessor;
        _identityContext = identityContext;
        _context = context;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _currentProcess.ProcessName = GetHandlerName();
        _currentProcess.CurrentUserId = GetUserId();
        _currentProcess.CurrentUserDetailId = GetUserDetailId();

        return Task.CompletedTask;
    }
    protected string GetHandlerName()
    {
        string handlerName = typeof(TRequest).DeclaringType.Name;
        string folderName = typeof(TRequest).Namespace.Split(".").Last();

        return folderName + "." + handlerName;
    }

    private string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    private long GetUserDetailId()
    {
        if (!string.IsNullOrWhiteSpace(_currentProcess.CurrentUserId))
        {
            long userDetailId = _context.UserDetails
                .Where(x => x.UserId == _currentProcess.CurrentUserId)
                .Select(x => x.UserDetailId)
                .FirstOrDefault();
            return userDetailId;
        }
        else
        {
            return 0;
        }
    }
}
