namespace BasicBudgetR.Server.Application.Handlers.User;
public class Login
{
    public record Request : IRequest<Result<NoValue>>
    {
    }

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            return Result.Success();
        }
    }
}
