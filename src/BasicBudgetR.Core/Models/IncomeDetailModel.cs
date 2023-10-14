﻿namespace BasicBudgetR.Core.Models;

public class IncomeDetailModel
{
    public long IncomeDetailId { get; set; }

    public long IncomeId { get; set; }

    public long BudgetMonthId { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }
    public string MonthName => new DateTime(Year, Month, 1).ToString("MMMM");
}