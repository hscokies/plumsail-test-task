namespace Application.Submissions.Create.AnswerModels;

public class SelectionAnswerModel : AnswerModel, ISingleOptionAnswer
{
    public int Value { get; init; }
}