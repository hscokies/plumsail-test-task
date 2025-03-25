using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class MultipleOptionsQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(MultipleOptionsQuestionModel);
    public override string GetDiscriminator() => Discriminator;
    public ICollection<QuestionOptionModel> Options { get; init; }

    public static implicit operator MultipleOptionsQuestionModel(MultipleOptionsQuestion entity)
    {
        return new MultipleOptionsQuestionModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Validator = entity.Validator,
            Options = entity.Options.Select(x => (QuestionOptionModel)x).ToArray(),
        };
    }
}