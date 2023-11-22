namespace BudgetR.Core.Extensions;
public static class CommonExtensions
{
    //generic method to see if a list is null or empty
    public static bool IsPopulated<T>(this IEnumerable<T> list)
    {
        return list != null && list.Any();
    }

    //extension method to see if a string is null or empty
    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    //extension method to see if nullable long is null or zero
    public static bool IsNullOrZero(this long? value)
    {
        return value == null || value == 0;
    }
}
