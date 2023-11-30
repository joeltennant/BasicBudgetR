namespace BudgetR.Core.Interfaces;
public interface IAuthenticationStateService
{
    public string? CurrentUserEmail();

    public (long? ApplicationUserId, long? UserId) CurrentUserId();
}
