using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }
        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && !string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result Fail(string error) => new Result(false, error);
        public static Result<TValue> Fail<TValue>(string error) => new Result<TValue>(default, false, error);
        public static Result Ok() => new Result(true, string.Empty);
        public static Result<TValue> Ok<TValue>(TValue value) => new Result<TValue>(value, true, string.Empty);
        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                {
                    return result;
                }               
            }
            return Ok();
        }
    }
    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public TValue Value
        {
            get
            {
                if (!IsSuccess)
                {
                    throw new InvalidOperationException();
                }
                return _value;
            }
        }
        protected internal Result(TValue value, bool success, string error) : base (success, error)
        {
            _value = value;
        }
    }
}
