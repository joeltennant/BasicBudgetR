using BasicBudgetR.Server.Domain;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class MonthBudgetConfiguration : IEntityTypeConfiguration<MonthBudget>
{
    public void Configure(EntityTypeBuilder<MonthBudget> builder)
    {
        builder.ToTable("MonthBudgets",
                       a => a.IsTemporal
                                  (
                                          a =>
                                          {
                                              a.UseHistoryTable("MonthBudgetHistory");
                                              a.HasPeriodStart(DomainConstants.CreatedAt);
                                              a.HasPeriodEnd(DomainConstants.ModifiedAt);
                                          }));
    }
}