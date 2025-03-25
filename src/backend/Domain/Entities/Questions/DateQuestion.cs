namespace Domain.Entities.Questions;

public class DateQuestion : QuestionBase, IQuestionWithPlaceholder
{
    public string Placeholder { get; set; }
}