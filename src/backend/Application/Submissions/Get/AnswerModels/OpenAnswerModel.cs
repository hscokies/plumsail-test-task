using Domain.Entities.Answers;

namespace Application.Submissions.Get.AnswerModels;

public class OpenAnswerModel : AnswerModel
{
    public string Value { get; init; }

    public static OpenAnswerModel Create(OpenAnswer answer)
    {
        return new OpenAnswerModel
        {
            Question = answer.Question.Title,
            Value = answer.Value
        };
    }
}