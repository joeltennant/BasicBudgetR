using BudgetR.Server.Infrastructure.Data.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BudgetR.Server.Application.Handlers.Users;
public class SetUser
{
    public record Request() : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly AuthenticationDbContext _authenticationDbContext;

        public Handler(BudgetRDbContext context, StateContainer stateContainer, IHttpContextAccessor httpContextAccessor, AuthenticationDbContext authenticationDbContext)
            : base(context, stateContainer)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationDbContext = authenticationDbContext;
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
