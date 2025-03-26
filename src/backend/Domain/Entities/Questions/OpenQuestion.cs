namespace Domain.Entities.Questions;

public class OpenQuestion : QuestionBase, IQuestionWithPlaceholder
{
    public string Placeholder { get; set; }
}