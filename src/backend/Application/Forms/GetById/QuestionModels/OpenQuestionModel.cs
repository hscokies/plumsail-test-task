using Domain.Entities.Questions;

namespace Application.Forms.GetById.QuestionModels;

public class OpenQuestionModel : QuestionModel, IPlaceholderQuestion
{
    public const string Discriminator = nameof(OpenQuestion);
    public override string GetDiscriminator() => Discriminator;
    public string Placeholder { get; init; }

    public static OpenQuestionModel Create(OpenQuestion question)
    {
        return new OpenQuestionModel
        {
            Id = question.Id,
            Title = question.Title,
            Placeholder = question.Placeholder,
            Validator = question.Validator
        };
    }
}