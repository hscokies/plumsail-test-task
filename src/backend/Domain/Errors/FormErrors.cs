using Domain.Primitives.Errors;

namespace Domain.Errors;

public static class FormErrors
{
    public static Error NotFound(int formId) => Error.NotFound(
        "Form.NotFound",
        $"Form with the ID = '{formId}' was not found");
}