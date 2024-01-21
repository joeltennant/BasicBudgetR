using BudgetR.Server.Domain.Entities;

namespace BudgetR.Server.BusinessRules.Transactions.Steps;
public class AssignAccounts : TransactionStepBase
{
    public AssignAccounts(BudgetRDbContext context, ServerContainer serverContainer)
        : base(context, serverContainer)
    {
    }

    public override TransactionProcessorDto Execute(TransactionProcessorDto transactions)
    {
        var accounts = _context.Accounts
            .Where(a => a.HouseholdId == _stateContainer.HouseholdId)
            .Select(a => new Account
            {
                AccountId = a.AccountId,
                LongName = a.LongName,
            })
            .ToList();

        foreach (var transaction in transactions.LoadedTransactions)
        {
            long? accountId = accounts
                .Where(a => a.LongName == transaction.AccountName)
                .Select(a => a.AccountId)
                .FirstOrDefault();

            if (accountId.HasValue && accountId > 0)
            {
                transaction.AccountId = accountId.Value;
            }
        }

        return transactions;
    }
}
