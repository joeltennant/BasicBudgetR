using BudgetR.Core.Interfaces;

namespace BudgetR.Services;

public class AuthenticationStateService : IAuthenticationStateService
{
    public string? CurrentUserEmail()
    {
        throw new NotImplementedException();
    }

    public (long? ApplicationUserId, long? UserId) CurrentUserId()
    {
        throw new NotImplementedException();
    }
}
