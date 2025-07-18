namespace CbMaker.SharedKernel
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error state", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Success<TValue>(TValue value) =>
            new(value, true, Error.None);

        public static Result<TValue> Failure<TValue>(Error error) =>
            new(default, false, error);
    }

    public class Result<TValue> : Result
    {
        public TValue Value { get; }

        internal Result(TValue value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<TValue> ValidationFailure(ValidationError error) =>
            new(default, false, error);
    }
}
