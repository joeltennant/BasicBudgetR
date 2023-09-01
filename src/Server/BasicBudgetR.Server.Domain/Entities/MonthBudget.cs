namespace BasicBudgetR.Server.Domain.Entities;
public class MonthBudget : BaseEntity
{
    [Key]
    [Column(Order = 0)]
    public long BudgetMonthId { get; set; }

    [Column(Order = 1)]
    public long MonthYearId { get; set; }
    public MonthYear? MonthYear { get; set; }
}
