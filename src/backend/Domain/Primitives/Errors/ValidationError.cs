using System.Collections.Generic;
using Domain.Enumerations;

namespace Domain.Primitives.Errors;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors)
        : base(
            "Validation.General",
            "One or more validation errors occurred",
            ErrorType.Validation)
    {
        Errors = errors;
    }

    public ICollection<Error> Errors { get; init; }
}