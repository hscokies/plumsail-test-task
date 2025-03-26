namespace Application.Models.Answers;

public class SelectionAnswerModel : AnswerModel, ISingleOptionAnswer
{
    public int Value { get; init; }
}