namespace BasicBudgetR.Server.Domain.Entities;

public class ExpenseDetail
{
    [Key]
    [Column(Order = 0)]
    public long ExpenseDetailId { get; set; }

    [Column(Order = 1)]
    public long ExpenseId { get; set; }

    [Column(Order = 2)]
    public long MonthBudgetId { get; set; }
    public MonthBudget? MonthBudget { get; set; }
}