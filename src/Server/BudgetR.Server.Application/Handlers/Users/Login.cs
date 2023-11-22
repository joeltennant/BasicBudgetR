using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BudgetR.Server.Application.Handlers.Users;
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

            User? user = _context.Users
                .Where(x => x.AuthId == authId)
                .Select(u => new User
                {
                    UserId = u.UserId,
                    HouseholdId = u.HouseholdId,
                    UserType = u.UserType,
                })
                .FirstOrDefault();

            if (user == null)
            {
                return Result.NotFound();
            }

            _stateContainer.UserId = user.UserId;
            _stateContainer.HouseholdId = user.HouseholdId;
            _stateContainer.UserType = user.UserType;

            return Result.Success();
        }
    }
}
