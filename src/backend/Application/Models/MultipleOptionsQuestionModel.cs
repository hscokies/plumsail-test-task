using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class MultipleOptionsQuestionModel : OptionsQuestionModel
{
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