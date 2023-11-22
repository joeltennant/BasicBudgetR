using BudgetR.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BudgetR.Server.Infrastructure.Data.Authentication;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
}
