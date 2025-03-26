using Domain.Entities.Answers;

namespace Application.Submissions.Get.AnswerModels;

public class SingleOptionAnswerModel : AnswerModel
{
    public string Value { get; init; }

    public static SingleOptionAnswerModel Create(OptionAnswer answer)
    {
        return new SingleOptionAnswerModel
        {
            Question = answer.Question.Title,
            Value = answer.Option.Value
        };
    }
}