using Domain.Entities.Questions;

namespace Domain.Entities;

public class QuestionOption
{
    public int Id { get; init; }
    public int QuestionId { get; init; }
    public OptionsQuestionBase Question { get; init; }
    public string Value { get; init; }
}