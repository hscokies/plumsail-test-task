using Domain.Entities;

namespace Application.Models;

public sealed class QuestionOptionModel
{
    public int Id { get; init; }
    public string Label { get; init; }

    public static implicit operator QuestionOptionModel(QuestionOption entity)
    {
        return new QuestionOptionModel()
        {
            Id = entity.Id,
            Label = entity.Value,
        };
    }
}