using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpenseTracker.Domain.Primitives
{
    public class Result
    {
        public bool Success { get; }
        public bool Failure => !Success;
        public string Error { get; }
        protected Result(bool success, string error)
        {
            if (success && !string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException();
            }

            if (!success && string.IsNullOrWhiteSpace(error))
            {
                throw new InvalidOperationException();
            }

            Success = success;
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
                if (result.Failure)
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
                if (!Success)
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
