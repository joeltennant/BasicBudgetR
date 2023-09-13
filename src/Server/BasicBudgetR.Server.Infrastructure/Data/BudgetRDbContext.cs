using BasicBudgetR.Server.Domain.Entities.ReferenceEntities;
using System.Reflection;

namespace BasicBudgetR.Server.Infrastructure.Data;
public class BudgetRDbContext : DbContext
{
    public BudgetRDbContext(DbContextOptions<BudgetRDbContext> options) : base(options)
    {
    }

    public DbSet<Household> Households { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BusinessTransactionActivity> BusinessTransactionActivities { get; set; }
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<MonthYear> MonthYears { get; set; }
    public DbSet<MonthBudget> MonthBudgets { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseDetail> ExpenseDetails { get; set; }
    public DbSet<Income> Incomes { get; set; }

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
