namespace Domain.Enumerations;

public enum ErrorType : byte
{
    Failure = 0,
    Validation = 1,
    Problem = 2,
    NotFound = 3,
    Conflict = 4
}