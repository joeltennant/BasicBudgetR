namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class BusinessTransactionActivityConfiguration : IEntityTypeConfiguration<BusinessTransactionActivity>
{
    public void Configure(EntityTypeBuilder<BusinessTransactionActivity> builder)
    {
        builder.HasData
            (
                new BusinessTransactionActivity
                {
                    BusinessTransactionActivityId = 1,
                    ProcessName = "Initial Seeding",
                    CreatedAt = DateTime.UtcNow,
                    UserId = 1
                }
            );
    }
}
