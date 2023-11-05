using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Extensions
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
            where T : class
        {
            return maybe.HasValue ? Result.Ok(maybe.Value) : Result.Fail<T>(errorMessage);
        }
        public static Result<T2> OnSuccess<T1, T2>(this Result<T1> result, Func<T1, T2> onSuccessFunc)
        {
            return result.IsSuccess ? Result.Ok<T2>(onSuccessFunc(result.Value)) : Result.Fail<T2>(result.Error);
        }
    }
}