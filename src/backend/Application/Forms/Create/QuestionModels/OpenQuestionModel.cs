using Domain.Entities.Questions;

namespace Application.Forms.Create.QuestionModels;

public class OpenQuestionModel : QuestionModel, IPlaceholderQuestion
{
    public const string Discriminator = nameof(OpenQuestion);

    public override string GetDiscriminator()
    {
        return Discriminator;
    }

    public string Placeholder { get; init; }
}