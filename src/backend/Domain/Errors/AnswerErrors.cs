using Domain.Primitives.Errors;

namespace Domain.Errors;

public static class AnswerErrors
{
    public static Error QuestionNotFound(int questionId)
    {
        return Error.NotFound(
            "Answer.Question.NotFound",
            $"Question with ID '{questionId}' not found.");
    }

    public static Error OptionNotFound(int questionId, int optionId)
    {
        return Error.NotFound(
            "Answer.Question.NotFound",
            $"Answer option with ID '{optionId}' not found on question with ID '{questionId}'.");
    }
}