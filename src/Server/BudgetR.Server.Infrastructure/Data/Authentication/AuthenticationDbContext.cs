using BudgetR.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BudgetR.Server.Infrastructure.Data.Authentication;
public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<ApplicationUser> MyProperty { get; set; }
}
