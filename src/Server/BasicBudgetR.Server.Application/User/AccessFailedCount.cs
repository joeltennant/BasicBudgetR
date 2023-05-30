namespace BasicBudgetR.Server.Application.User;

public static class AccessFailedCount
{
    public record Request : IRequest<Response>
    {
    }

    public record Response(long AccountId);

    public class Handler : BaseHandler, IRequestHandler<Request, Response>
    {
        public Handler(ApplicationDbContext context, CurrentProcess currentProcess)
            : base(context, currentProcess)
        {
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            return new Response(1);
        }
    }
}
