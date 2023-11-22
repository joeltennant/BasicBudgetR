using Microsoft.AspNetCore.Identity;

namespace BudgetR.Core.Identity;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public long UserId { get; set; }
}

