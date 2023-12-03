using Microsoft.AspNetCore.Http;

namespace BudgetR.Server.Application.Handlers.Users;
public static class LoadUserAction
{
    public record Request() : IRequest<Result<Action>>;

    public class Handler : BaseHandler<Action>, IRequestHandler<Request, Result<Action>>
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public Handler(BudgetRDbContext context, StateContainer stateContainer, IHttpContextAccessor httpContextAccessor)
            : base(context, stateContainer)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<Action>> Handle(Request request, CancellationToken cancellationToken)
        {
            Action action;

            if (_stateContainer.UserId.IsNullOrZero())
            {
                action = Action.FinishRegistration;
            }
            else if (_stateContainer.IsActive.IsFalse())
            {
                action = Action.ReactivateAccount;
            }
            else
            {
                action = Action.Continue;
            }

            return Result.Success(action);
        }
    }

    public enum Action
    {
        Continue,
        FinishRegistration,
        ReactivateAccount,
    }
}
