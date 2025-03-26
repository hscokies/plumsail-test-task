using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Answers;

namespace Application.Submissions.Get.AnswerModels;

public class MultipleOptionsAnswerModel : AnswerModel
{
    public ICollection<string> Value { get; set; }

    public static MultipleOptionsAnswerModel Create(ICollection<OptionAnswer> answer)
    {
        return new MultipleOptionsAnswerModel
        {
            Question = answer.First().Question.Title,
            Value = answer.Select(x => x.Option.Value).ToArray()
        };
    }
}