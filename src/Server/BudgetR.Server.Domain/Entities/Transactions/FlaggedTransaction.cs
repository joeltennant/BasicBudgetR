namespace BudgetR.Server.Domain.Entities.Transactions;
public class FlaggedTransaction : BaseEntity
{
    [Key]
    [Column(Order = 1)]
    public long FlaggedTransactionId { get; set; }
    [Column(Order = 2)]
    public long? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }
    [Column(Order = 3)]
    public FlagType FlagType { get; set; }
}

public enum FlagType
{
    Duplicate,
    MiscCategory,
    ErrorProcessing
}