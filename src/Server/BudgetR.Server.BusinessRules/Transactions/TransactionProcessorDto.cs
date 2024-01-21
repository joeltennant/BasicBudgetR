using BudgetR.Server.Domain.Dtos;

namespace BudgetR.Server.BusinessRules.Transactions;
public class TransactionProcessorDto
{
    //(List<LoadedTransactionDto> LoadedTransactions, ) Transactions
    public List<Transaction>? TransactionEntities { get; set; }
    public List<LoadedTransactionDto>? LoadedTransactions { get; set; }
}