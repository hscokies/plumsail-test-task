using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class OpenQuestionModel : QuestionModel, IPlaceholderQuestion
{
    public const string Discriminator = nameof(OpenQuestion);
    public override string GetDiscriminator() => Discriminator;
    public string Placeholder { get; init; }

    public static implicit operator OpenQuestionModel(OpenQuestion entity)
    {
        return new OpenQuestionModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Placeholder = entity.Placeholder,
            Validator = entity.Validator,
        };
    }
}