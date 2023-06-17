using BasicBudgetR.Server.Domain;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
{
    public void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        builder.ToTable("UserDetails",
                        a => a.IsTemporal(
                                  a =>
                                  {
                                      a.HasPeriodStart(DomainConstants.CreatedAt);
                                      a.HasPeriodEnd(DomainConstants.ModifiedAt);
                                      a.UseHistoryTable("UserDetailHistory");
                                  }));
    }
}
