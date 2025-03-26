using System;
using Domain.Entities.Answers;

namespace Application.Submissions.Get.AnswerModels;

public class DateAnswerModel : AnswerModel
{
    public DateOnly Value { get; init; }

    public static DateAnswerModel Create(DateAnswer answer)
    {
        return new DateAnswerModel
        {
            Question = answer.Question.Title,
            Value = answer.Value
        };
    }
}