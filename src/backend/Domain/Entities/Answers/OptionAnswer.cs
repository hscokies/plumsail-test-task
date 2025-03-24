namespace Domain.Entities.Answers;

public class OptionAnswer : AnswerBase
{
    public int OptionId { get; init; }
    public QuestionOption Option { get; init; }
}