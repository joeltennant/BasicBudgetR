using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasicBudgetR.Server.Application.Handlers.Users;
public static class Login
{
    public record Request() : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public Handler(BudgetRDbContext context, StateContainer stateContainer, IHttpContextAccessor httpContextAccessor)
            : base(context, stateContainer)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {
            string authId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            User? user = _context.Users.Where(x => x.AuthId == authId).FirstOrDefault();

            if (user == null)
            {
                return Result.NotFound();
            }

            _stateContainer.CurrentUserId = user.UserId;
            _stateContainer.HouseholdId = user.HouseholdId;

            return Result.Success();
        }
    }
}
