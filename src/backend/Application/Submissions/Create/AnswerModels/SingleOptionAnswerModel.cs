namespace Application.Submissions.Create.AnswerModels;

public class SingleOptionAnswerModel : AnswerModel, ISingleOptionAnswer
{
    public int Value { get; init; }
}