using BasicBudgetR.Server.Domain.Entities.ReferenceEntities;
using System.Reflection;

namespace BasicBudgetR.Server.Infrastructure.Data;
public class BudgetRDbContext : DbContext
{
    public BudgetRDbContext(DbContextOptions<BudgetRDbContext> options) : base(options)
    {
    }

    public DbSet<UserDetail> UserDetails { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }

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
