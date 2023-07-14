namespace BasicBudgetR.Server.Domain.Enums;
public static class Enum
{
    public enum ExpenseType
    {
        Rent = 0,
        Mortgage = 1,
        Utilities = 2,
        Groceries = 3,
        Gas = 4,
        Insurance = 5,
        Entertainment = 6,
        Other = 7
    }

    public enum AccountTypes
    {
        Checking,
        Savings,
        CreditCard,
        Cash,
        Investment,
        Loan,
        Other
    }

    public enum IncomeType
    {
        Paycheck,
        Interest,
        Dividend,
        Other
    }
}
