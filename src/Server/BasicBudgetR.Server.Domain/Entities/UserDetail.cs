namespace BasicBudgetR.Server.Domain.Entities;
public class UserDetail
{
    public long UserDetailId { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
}
