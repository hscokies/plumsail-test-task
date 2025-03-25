using System;
using Domain.Primitives.Errors;

namespace Domain.Primitives;

public class Result
{
    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new Result<TValue>(true, value, Error.None);
    }

    private static Result Failure(Error error)
    {
        return new Result(false, error);
    }

    public static implicit operator Result(Error error)
    {
        return new Result(false, error);
    }

    public TOut Match<TOut>(
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return IsSuccess ? onSuccess() : onFailure(this);
    }
}

public class Result<TValue> : Result
{
    public Result(bool isSuccess, TValue value, Error error) : base(isSuccess, error)
    {
        Value = value;
    }

    public TValue Value { get; }

    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>(true, value, Error.None);
    }
    
    public static implicit operator Result<TValue>(Error error)
    {
        return new Result<TValue>(false, default, error);
    }

    public TOut Match<TOut>(
        Func<TValue, TOut> onSuccess,
        Func<Result<TValue>, TOut> onFailure)
    {
        return IsSuccess ? onSuccess(Value) : onFailure(this);
    }
}