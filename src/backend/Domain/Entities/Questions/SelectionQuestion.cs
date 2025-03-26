namespace Domain.Entities.Questions;

public class SelectionQuestion : OptionsQuestionBase, IQuestionWithPlaceholder
{
    public string Placeholder { get; set; }
}