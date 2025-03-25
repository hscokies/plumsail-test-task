using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class SingleOptionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SingleOptionQuestion);
    public override string GetDiscriminator() => Discriminator;
    public ICollection<QuestionOptionModel> Options { get; init; }
    public static implicit operator SingleOptionQuestionModel(SingleOptionQuestion entity)
    {
        return new SingleOptionQuestionModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            Validator = entity.Validator,
            Options = entity.Options.Select(x => (QuestionOptionModel)x).ToArray(),
        };
    }
}