using System.Collections.Generic;

namespace Application.Models.Answers;

public class MultipleOptionsAnswerModel : AnswerModel
{
    public HashSet<int> Value { get; init; }
}