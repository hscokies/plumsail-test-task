namespace Application.Models.Answers;

public class SingleOptionAnswerModel : AnswerModel, ISingleOptionAnswer
{
    public int Value { get; init; }
}