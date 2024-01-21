namespace BudgetR.Server.BusinessRules.Transactions;
public abstract class TransactionStepBase
{
    protected readonly BudgetRDbContext _context;
    protected readonly ServerContainer _stateContainer;

    protected TransactionStepBase(BudgetRDbContext context, ServerContainer serverContainer)
    {
        _context = context;
        _stateContainer = serverContainer;
    }

    public abstract TransactionProcessorDto Execute(TransactionProcessorDto transaction);
}
