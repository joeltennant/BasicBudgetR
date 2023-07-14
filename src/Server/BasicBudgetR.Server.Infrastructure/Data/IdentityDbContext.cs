using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;

namespace BasicBudgetR.Server.Infrastructure.Data;
public class IdentityDbContext : ApiAuthorizationDbContext<User>
{
    public IdentityDbContext(DbContextOptions options
                              , IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
}
