using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class SelectionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SelectionQuestion);
    public override string GetDiscriminator() => Discriminator;
    public string Placeholder { get; init; }
    public ICollection<QuestionOptionModel> Options { get; init; }
    public static implicit operator SelectionQuestionModel(SelectionQuestion entity)
    {
        return new SelectionQuestionModel
        {
            Id = entity.Id,
            Placeholder = entity.Placeholder,
            Title = entity.Title,
            Validator = entity.Validator,
            Options = entity.Options.Select(x => (QuestionOptionModel)x).ToArray(),
        };
    }
}