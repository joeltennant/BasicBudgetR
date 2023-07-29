namespace BasicBudgetR.Server.Domain.Entities;
public class UserDetail
{
    [Key]
    [Column(Order = 0)]
    public long UserDetailId { get; set; }

    [Column(Order = 1)]
    public string? UserId { get; set; }
    [Column(Order = 2)]
    public string? FirstName { get; set; }
    [Column(Order = 3)]
    public string? LastName { get; set; }
    [Column(Order = 4)]
    public long HouseholdId { get; set; }
    public Household? Household { get; set; }
}
