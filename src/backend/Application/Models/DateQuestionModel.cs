using System.Text.Json.Serialization;
using Application.Forms.Get;
using Domain.Entities.Questions;

namespace Application.Models;

public class DateQuestionModel : QuestionModel
{
    public string Placeholder { get; init; }
    public static implicit operator DateQuestionModel(DateQuestion entity)
    {
        return new DateQuestionModel()
        {
            Id = entity.Id,
            Title = entity.Title,
            Placeholder = entity.Placeholder,
            Validator = entity.Validator,
        };
    }
}