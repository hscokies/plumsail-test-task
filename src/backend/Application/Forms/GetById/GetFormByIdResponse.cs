using System.Collections.Generic;
using Application.Models.Questions;

namespace Application.Forms.GetById;

public record GetFormByIdResponse(
    int Id,
    string Title,
    string Subtitle,
    string Color)
{
    public ICollection<QuestionModel> Questions { get; } = new List<QuestionModel>();
}