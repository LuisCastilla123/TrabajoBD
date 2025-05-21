namespace CbMaker.SharedKernel;

public class AppError
{
    public static readonly AppError None = new AppError(string.Empty);
    public string Message { get; }

    public AppError(string message)
    {
        Message = message;
    }

    public override string ToString() => Message;
}

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public AppError Error { get; }

    protected Result(bool isSuccess, AppError error)
    {
        if (isSuccess && error != AppError.None ||
            !isSuccess && error == AppError.None)
        {
            throw new ArgumentException("Invalid error state", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, AppError.None);

    public static Result Failure(AppError error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, AppError.None);

    public static Result<TValue> Failure<TValue>(AppError error) =>
        new(default, false, error);
}

public class Result<TValue> : Result
{
    public TValue Value { get; }

    internal Result(TValue value, bool isSuccess, AppError error)
        : base(isSuccess, error)
    {
        Value = value;
    }
}

