namespace BasicBudgetR.Server.Domain.Entities;
public class BusinessTransactionActivity
{
    [Key]
    [Column(Order = 0)]
    public long BusinessTransactionActivityId { get; set; }
    [Column(Order = 1)]
    public string ProcessName { get; set; }

    [Column(Order = 2)]
    public DateTime CreatedAt { get; set; }

    [Column(Order = 3)]
    public long UserDetailId { get; set; }

    public User? UserDetail { get; set; }
}
