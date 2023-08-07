using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasicBudgetR.Server.Application.PipelineBehaviors;

public class PreRequestBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private CurrentProcess _currentProcess;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly BudgetRDbContext _context;

    public PreRequestBehavior(CurrentProcess currentProcess
        , IHttpContextAccessor httpContextAccessor
        , IdentityDbContext identityDbContext
        , BudgetRDbContext context)
    {
        _currentProcess = currentProcess;
        _httpContextAccessor = httpContextAccessor;

        _context = context;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _currentProcess.ProcessName = GetHandlerName();
        _currentProcess.CurrentUserId = GetUserId();
        //GetUserDetailId();

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
}
