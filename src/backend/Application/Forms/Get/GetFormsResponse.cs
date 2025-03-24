using System.Collections.Generic;
using Application.Models;

namespace Application.Forms.Get;

public sealed class GetFormsResponse : List<GetFormModel>;

public sealed record GetFormModel(int FormId)
{
    public ICollection<QuestionModel> Questions { get; } = new List<QuestionModel>();
}