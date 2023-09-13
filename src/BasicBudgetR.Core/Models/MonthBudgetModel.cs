namespace BasicBudgetR.Core.Models;
public class MonthBudgetModel
{
    public long BudgetMonthId { get; set; }
    public long MonthYearId { get; set; }
    public MonthYearModel? MonthYear { get; set; }
    public decimal IncomeTotal { get; set; }
    public decimal ExpenseTotal { get; set; }
}
