using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace BasicBudgetR.Server.Infrastructure.Data;
public class BbrDbContext : ApiAuthorizationDbContext<User>
{
    public BbrDbContext(DbContextOptions options
                              , IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.GetForeignKeys()
                      .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                      .ToList()
                      .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }
    }
}
