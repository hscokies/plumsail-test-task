using System.Collections.Generic;

namespace Application.Submissions.Create.AnswerModels;

public class MultipleOptionsAnswerModel : AnswerModel
{
    public HashSet<int> Value { get; init; }
}