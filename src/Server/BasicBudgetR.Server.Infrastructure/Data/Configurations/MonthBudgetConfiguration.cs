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

        builder.HasData(BuildMonthBudgetList());
    }

    private List<MonthBudget> BuildMonthBudgetList()
    {
        //loop 120 times to make list of MonthBudget entity and add to list
        List<MonthBudget> monthBudgets = new();
        for (int i = 1; i <= 120; i++)
        {
            monthBudgets.Add(new MonthBudget
            {
                BudgetMonthId = i,
                MonthYearId = i,
            });
        }
        return monthBudgets;
    }
}