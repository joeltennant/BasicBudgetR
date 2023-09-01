using BasicBudgetR.Core;
using BasicBudgetR.Server.Domain;
using BasicBudgetR.Server.Domain.Entities.ReferenceEntities;

namespace BasicBudgetR.Server.Infrastructure.Data.Configurations;
public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
{
    public void Configure(EntityTypeBuilder<AccountType> builder)
    {
        builder.ToTable("AccountTypes");

        builder.HasData(
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Cash, Name = "Cash" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Savings, Name = "Savings" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Checking, Name = "Checking" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.CreditCard, Name = "Credit Card" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Investment, Name = "Investment" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Loan, Name = "Loan" },
            new AccountType { AccountTypeId = AppConstants.AccountTypes.Other, Name = "Other" }
        );
    }
}
