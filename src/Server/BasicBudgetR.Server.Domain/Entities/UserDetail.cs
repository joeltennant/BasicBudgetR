using System.ComponentModel.DataAnnotations;

namespace BasicBudgetR.Server.Domain.Entities;
public class UserDetail
{
    [Key]
    public long UserDetailId { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
}
