using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common.Errors;

namespace dress_u_backend.Common
{
    public class Result<TValue>
    {
        private readonly TValue? _value;
        private readonly Error _error;
        private readonly bool _isSuccess;
        private Result(Error error, TValue? value = default)
        {
            _isSuccess = error == Error.None;
            _error = error;
            _value = value;
        }

        public bool IsFailure => !_isSuccess;

        public TResult Match<TResult>(
            Func<TValue, TResult> success, Func<Error, TResult> failure)
        {
            return _isSuccess ? success(_value!) : failure(_error);
        }

        public static Result<TValue> Success(TValue value)
            => new(error: Error.None, value);

        public static Result<TValue> Failure(Error error)
            => new(error: error);

        public static implicit operator Result<TValue>(Error error)
            => new(error: error);

        public static implicit operator Result<TValue>(TValue value)
            => new(error: Error.None, value);
    }
}