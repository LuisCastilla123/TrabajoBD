using CbMaker.SharedKernel;

namespace CbMaker.API.Extensions
{
    public static class ResultExtensions
    {
        public static Tout Match<Tout>(
            this Result result,
            Func<Tout> onSuccess,
            Func<Result, Tout> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result);
        }

        public static Tout Match<TIn, Tout>(
            this Result<TIn> result,
            Func<TIn, Tout> onSuccess,
            Func<Result<TIn>, Tout> onFailure)
        {
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
        }
    }
}
