using System.Collections.Generic;
using Domain.Entities;

namespace Application.Models;

public abstract class OptionsQuestionModel : QuestionModel
{
    public ICollection<QuestionOptionModel> Options { get; init; }
}