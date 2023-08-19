using BasicBudgetR.Core.Enums;
using FluentValidation.Results;

namespace BasicBudgetR.Server.Application.Common;
public class Result<T>
{
    public T? Value { get; private set; }

    public bool? IsSuccess { get; }
    public ErrorType ErrorType { get; }
    public IList<ValidationFailure>? Errors { get; }

    public Result() { }

    #region ---Constructors---

    //Success Constructor
    public Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    //Error Constructor
    public Result(IList<ValidationFailure> errors)
    {
        this.Errors = errors;
        this.ErrorType = ErrorType.Validation;
    }

    //Error with type only
    public Result(ErrorType errorType)
    {
        this.ErrorType = errorType;
    }

    #endregion

    #region ---Result Methods---

    public Result<T> Error(IList<ValidationFailure> errors)
    {
        return new Result<T>(errors);
    }

    //Success Method
    public Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public Result<T> Success()
    {
        return new Result<T>(true);
    }

    //Not Authorized Method
    public Result<T> NotAuthorized()
    {
        return new Result<T>(ErrorType.NotAuthorized);
    }

    //Not Found Method  
    public Result<T> NotFound()
    {
        return new Result<T>(ErrorType.NotFound);
    }

    #endregion
}

public record NoValue();