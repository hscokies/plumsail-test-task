using Domain.Entities.Questions;

namespace Application.Forms.Create.QuestionModels;

public class DateQuestionModel : QuestionModel, IPlaceholderQuestion
{
    public const string Discriminator = nameof(DateQuestion);

    public override string GetDiscriminator()
    {
        return Discriminator;
    }


    public string Placeholder { get; init; }
}