

using BudgetR.Server.Domain.Dtos;
using System.Data;

namespace BudgetR.Server.BusinessRules.Transactions.Steps;
public class AssignCategories : TransactionStepBase
{
    public AssignCategories(BudgetRDbContext context, ServerContainer serverContainer)
        : base(context, serverContainer)
    {
    }

    public override TransactionProcessorDto Execute(TransactionProcessorDto transactions)
    {
        var categories = _context.TransactionCategories
            .Where(t => t.HouseholdId == _stateContainer.HouseholdId)
            .ToList();

        var categoryRules = _context.TransactionCategoryRules
            .Where(t => t.HouseholdId == _stateContainer.HouseholdId)
            .ToList();

        var transactionTypeRules = _context.TransactionTypeRules
            .Where(t => t.HouseholdId == _stateContainer.HouseholdId)
            .ToList();

        HashSet<(TransactionType type, LoadedTransactionDto transaction)> transactionHashset = new();

        //Determine Types
        foreach (var type in transactionTypeRules.OrderBy(t => t.RuleLevel))
        {
            transactions.LoadedTransactions
                .Where(t => t.TransactionType == type.RuleOnTransactionType
                            && CheckCategoryRule(type, t))
                .ToList()
                .ForEach(t => t.TransactionType = type.AssignTransactionType);
        }

        //Assign Categories

        foreach (var rule in categoryRules)
        {
            transactions.LoadedTransactions
                .Where(t => t.TransactionType == rule.TransactionType && t.Description.Contains(rule.Rule))
                .ToList()
                .ForEach(t => t.CategoryId = rule.CategoryId);
        }

        return transactions;
    }

    private bool CheckCategoryRule(TransactionTypeRule rule, LoadedTransactionDto t) => rule.ComparisonType switch
    {
        ComparisonType.Like => t.Description.Contains(rule.StringRule),
        ComparisonType.Equal => t.Amount == rule.NumericRule,
        ComparisonType.GreaterThanOrEqualTo => t.Amount >= rule.NumericRule,
        ComparisonType.LessThanOrEqualTo => t.Amount <= rule.NumericRule,
        _ => false//default
    };
}
