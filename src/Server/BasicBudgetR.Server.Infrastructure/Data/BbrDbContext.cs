using BasicBudgetR.Server.Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BasicBudgetR.Server.Infrastructure.Data;
public class BbrDbContext : ApiAuthorizationDbContext<User>
{
    public BbrDbContext(DbContextOptions options
                              , IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    public DbSet<UserDetail> UserDetails { get; set; }
}
