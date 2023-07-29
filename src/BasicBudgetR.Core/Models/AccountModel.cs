using BasicBudgetR.Core.Enums;

namespace BasicBudgetR.Core.Models;

public class AccountModel
{
    public long AccountId { get; set; }

    public string? Name { get; set; }

    public decimal Balance { get; set; }

    public BalanceType BalanceType { get; set; }

    public long AccountTypeId { get; set; }

    public string AccountType { get; set; }

    public decimal BalanceWithSign
    {
        get
        {
            return BalanceType switch
            {
                BalanceType.Debit => Balance,
                BalanceType.Credit => -Balance,
            };
        }
    }
}
