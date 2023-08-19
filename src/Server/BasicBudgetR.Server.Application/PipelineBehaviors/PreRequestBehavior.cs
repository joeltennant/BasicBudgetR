using System.Security.Claims;

namespace BasicBudgetR.Server.Application.PipelineBehaviors;

public class PreRequestBehavior<TRequest> : IRequestPreProcessor<TRequest>
{
    private StateContainer _stateContainer;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PreRequestBehavior(CurrentProcessstateContainer
        , IHttpContextAccessor httpContextAccessor)
    {
        _stateContainer =stateContainer;
        _httpContextAccessor = httpContextAccessor;

    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _stateContainer.ProcessName = GetHandlerName();
        _stateContainer.CurrentUserId.Value = GetUserId();
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
