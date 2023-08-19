namespace BasicBudgetR.Server.Application.Handlers.User;
public static class Login
{
    public record Request : IRequest<Result<NoValue>>
    {
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        public Handler(BudgetRDbContext context, StateContainer stateContainer)
            : base(context,stateContainer)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            return Result.Success();
        }
    }
}
