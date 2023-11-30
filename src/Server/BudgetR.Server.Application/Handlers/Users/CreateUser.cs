using BudgetR.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgetR.Server.Application.Handlers.Users;
public class CreateUser
{
    public record Request(string HouseholdName, string DisplayName) : IRequest<Result<NoValue>>;

    public class Handler : BaseHandler<NoValue>, IRequestHandler<Request, Result<NoValue>>
    {
        public Handler(BudgetRDbContext context, StateContainer stateContainer)
            : base(context, stateContainer)
        {
        }

        public async Task<Result<NoValue>> Handle(Request request, CancellationToken cancellationToken)
        {

            long BtaId = await CreateBta(true, "Users.SignUp");

            User user = new()
            {
                AuthId = authId,
                DisplayName = request.DisplayName,
                UserType = UserType.User,
                BtaId = BtaId,
            };

            Household household = new()
            {
                Name = request.HouseholdName,
                BusinessTransactionActivityId = BtaId,
                Users = new List<User> { user },
            };

            await _context.Households.AddAsync(household);
            await _context.SaveChangesAsync();

            _stateContainer.UserId = user.UserId;
            _stateContainer.HouseholdId = user.HouseholdId;

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
