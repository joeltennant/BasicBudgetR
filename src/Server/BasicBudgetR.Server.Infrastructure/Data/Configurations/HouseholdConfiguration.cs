using BasicBudgetR.Server.Domain;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class HouseholdConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Households",
            a => a.IsTemporal
            (
                a =>
                {
                    a.UseHistoryTable("HouseholdHistory");
                    a.HasPeriodStart(DomainConstants.CreatedAt);
                    a.HasPeriodEnd(DomainConstants.ModifiedAt);
                }));
    }
}
