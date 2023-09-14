namespace BasicBudgetR.Server.Domain.Entities;

public class Income : BaseEntity
{
    [Key]
    [Column(Order = 0)]
    public long IncomeId { get; set; }
}