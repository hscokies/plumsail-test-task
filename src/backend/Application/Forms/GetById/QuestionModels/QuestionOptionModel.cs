using Domain.Entities;

namespace Application.Forms.GetById.QuestionModels;

public sealed class QuestionOptionModel
{
    public int Id { get; init; }
    public string Label { get; init; }

    public static QuestionOptionModel Create(QuestionOption question)
    {
        return new QuestionOptionModel
        {
            Id = question.Id,
            Label = question.Value
        };
    }
}