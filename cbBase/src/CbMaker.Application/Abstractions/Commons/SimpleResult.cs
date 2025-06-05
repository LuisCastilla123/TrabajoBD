using CbMaker.Application.Common;
using CbMaker.Application.Features.JobTitles.Create;
using FluentValidation;
using MediatR;

namespace CbMaker.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string? ErrorCode { get; }
        public string? ErrorMessage { get; }

        private Result(bool success, string? errorCode = null, string? errorMessage = null)
        {
            IsSuccess = success;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new(true);
        public static Result Failure(string code, string message) => new(false, code, message);
        public static Result Failure(Error error) => new(false, error.Code, error.Message);
    }

    public class Error
    {
        public string Code { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;

        public static Error Conflict(string code, string message) => new() { Code = code, Message = message };
        public static Error Problem(string code, string message) => new() { Code = code, Message = message };
    }
}

