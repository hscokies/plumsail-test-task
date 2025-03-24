using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class SelectionQuestionModel : OptionsQuestionModel
{
    public string Placeholder { get; init; }
    
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