using BasicBudgetR.Server.Domain;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users",
                        a => a.IsTemporal(
                                  a =>
                                  {
                                      a.HasPeriodStart(DomainConstants.CreatedAt);
                                      a.HasPeriodEnd(DomainConstants.ModifiedAt);
                                      a.UseHistoryTable("UserHistory");
                                  }));
    }
}
