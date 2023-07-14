namespace BasicBudgetR.Server.Domain.Entities;
public class BusinessTransactionActivity
{
    [Key]
    [Column(Order = 0)]
    public int BusinessTransactionActivityId { get; set; }
    [Column(Order = 1)]
    public string ProcessName { get; set; }

    [Column(Order = 2)]
    public long UserDetailId { get; set; }

    public UserDetail? UserDetail { get; set; }
}
