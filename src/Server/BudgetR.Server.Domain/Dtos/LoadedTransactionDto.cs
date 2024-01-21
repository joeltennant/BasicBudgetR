namespace BudgetR.Server.Domain.Dtos;
public class LoadedTransactionDto : TransactionDto
{
    public long? CategoryId { get; set; }
    public long? AccountId { get; set; }
    public TransactionType? TransactionType { get; set; }
    public Sign? Sign { get; set; }
}
