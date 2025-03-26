using Domain.Entities.Questions;

namespace Application.Forms.GetById.QuestionModels;

public class DateQuestionModel : QuestionModel, IPlaceholderQuestion
{
    public const string Discriminator = nameof(DateQuestion);
    public override string GetDiscriminator() => Discriminator;
    public string Placeholder { get; init; }

    public static DateQuestionModel Create(DateQuestion question)
    {
        return new DateQuestionModel
        {
            Id = question.Id,
            Title = question.Title,
            Placeholder = question.Placeholder,
            Validator = question.Validator
        };
    }
}