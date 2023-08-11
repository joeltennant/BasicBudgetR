namespace BasicBudgetR.Server.Application.Common;
public class Result<T>
{
    public T? Value { get; private set; }

    public ErrorType ErrorType { get; set; }
    public IList<string> ErrorMessages { get; set; } = new List<string>();
}

public enum ErrorType
{
    NotAuthorized,
    NotFound,
    Invalid,
    SystemError,
    Validation
}
