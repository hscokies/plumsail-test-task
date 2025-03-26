using Domain.Primitives.Errors;

namespace Domain.Errors;

public static class AnswerErrors
{
    public static Error QuestionNotFound(int answerId)
    {
        return Error.NotFound(
            "Answer.Question.NotFound",
            $"Question for answer with the ID = '{answerId}' was not found");
    }

    public static Error OptionNotFound(int answerId, int optionId)
    {
        return Error.NotFound(
            "Answer.Question.NotFound",
            $"Answer option with the ID = '{optionId}' was not found for answer with the ID = '{answerId}'");
    }
}