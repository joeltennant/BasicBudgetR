namespace BasicBudgetR.Server.Domain.Entities;
public class User
{
    [Key]
    [Column(Order = 0)]
    public long UserId { get; set; }

    [Column(Order = 1)]
    public string? AuthId { get; set; }

    [Column(Order = 2)]
    public string? DisplayName { get; set; }

    [Column(Order = 4)]
    public long? HouseholdId { get; set; }

    public Household? Household { get; set; }

    [Column(Order = 5)]
    public UserType UserType { get; set; }

    public long BtaId { get; set; }
}
