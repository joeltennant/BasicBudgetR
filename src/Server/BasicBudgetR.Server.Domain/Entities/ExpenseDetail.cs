namespace BasicBudgetR.Server.Domain.Entities;

public class ExpenseDetail : BaseEntity
{
    [Key]
    [Column(Order = 0)]
    public long ExpenseDetailId { get; set; }

    [Column(Order = 1)]
    public long ExpenseId { get; set; }
    public Expense? Expense { get; set; }

    [Column(Order = 2)]
    public long BudgetMonthId { get; set; }
    public BudgetMonth? BudgetMonth { get; set; }
}