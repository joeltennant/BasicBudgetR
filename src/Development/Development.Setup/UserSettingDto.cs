namespace BudgetR.Development.Setup;
public class UserSettingDto
{
    public string AuthId { get; set; }
    public string DisplayName { get; set; }
    public string HouseholdName { get; set; }
    public List<AccountSeedDto> Accounts { get; set; }
}

public class AccountSeedDto
{
    public string AccountName { get; set; }
    public long AccountType { get; set; }
    public decimal Balance { get; set; }
    public int BalanceType { get; set; }
}
