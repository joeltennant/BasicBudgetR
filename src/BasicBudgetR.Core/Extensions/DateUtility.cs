namespace BasicBudgetR.Core.Extensions;
public static class DateUtility
{
    public static DateTime LastDayFromParts(int Month, int Year, int Day = 1)
    {
        return new DateTime(Month, Year, Day).AddMonths(1).AddMinutes(-1);
    }
}

