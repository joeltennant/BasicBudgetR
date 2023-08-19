namespace BasicBudgetR.Server.Application.Handlers.User;
public class SignUp
{
    public record Request : IRequest<Result<long>>
    {
    }

    public class Handler : BaseHandler<long>, IRequestHandler<Request, Result<long>>
    {
        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Result<long>> Handle(Request request, CancellationToken cancellationToken)
        {
            return new Result<long>(1);
        }
    }
}
