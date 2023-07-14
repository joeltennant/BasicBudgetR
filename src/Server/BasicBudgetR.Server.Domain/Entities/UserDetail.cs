namespace BasicBudgetR.Server.Domain.Entities;
public class UserDetail
{
    [Key]
    [Column(Order = 0)]
    public long UserDetailId { get; set; }

    [Column(Order = 1)]
    public string UserId { get; set; }
}
