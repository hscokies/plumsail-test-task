using System.Linq;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;

namespace Application.Models;

public class SingleOptionQuestionModel : OptionsQuestionModel
{
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