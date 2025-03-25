namespace Domain.Entities.Questions;

public abstract class QuestionBase
{
    public int Id { get; init; }
    public int FormId { get; init; }
    public Form Form { get; init; }
    public string Key { get; set; }
    public string Title { get; set; }
    public string Discriminator { get; set; }
    public string Validator { get; set; }
}