using System;
using System.Collections.Generic;
using Smooth.Algebraics;
using Smooth.Algebraics.Results;
using Smooth.Extensions.Collections;
using Smooth.Slinq;

namespace Smooth.Extensions.Algebraic
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Option<T> o)
        {
            return o.isSome
                ? Result<T>.FromValue(o.value)
                : Result<T>.FromError("Value was missing");
        }

        public static Result<T> ToResult<T>(this Option<T> o, string errorMessage)
        {
            return o.isSome
                ? Result<T>.FromValue(o.value)
                : Result<T>.FromError(errorMessage);
        }

        public static Result<T> ToResult<T>(this Option<T> o, Func<string> errorFunc)
        {
            return o.Cata((v, _) => v.ToValue(), Unit.Default, f => Result<T>.FromError(f()), errorFunc);
        }

        public static Result<T> ToResult<T, TP>(this Option<T> o, Func<TP, string> errorFunc, TP errorParam)
        {
            return o.Cata((v, _) => v.ToValue(), Unit.Default,
                t => Result<T>.FromError(t.func(t.param)), (func: errorFunc, param: errorParam));
        }

        public static Result<T> ToValue<T>(this T v)
        {
            return Result<T>.FromValue(v);
        }

        public static Result<T> ToError<T>(this T _, string error)
        {
            return string.IsNullOrEmpty(error)
                ? Result<T>.FromError("Generic error")
                : Result<T>.FromError(error);
        }

        public static Result<List<T>> All<T>(IEnumerable<Result<T>> results)
        {
            return results.Slinq().AggregateWhile(Result<List<T>>.FromValue(new List<T>()),
                (list, result) => !list.IsError
                    ? result.Then((v, l) => Result<List<T>>.FromValue(l.Value.WithItem(v)), list)
                        .SpecifyError("One of items has an error")
                        .ToSome()
                    : Option<Result<List<T>>>.None);
        }
    }
}