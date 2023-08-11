namespace BasicBudgetR.Server.Application.Handlers.User;
public class SignUp
{
    public record Request : IRequest<Response>
    {
    }

    public record Response(long AccountId);

    public class Handler : BaseHandler, IRequestHandler<Request, Response>
    {
        public Handler(BudgetRDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return new Response(1);
        }
    }
}
