using System.Collections.Generic;

namespace Application.Forms.GetById.QuestionModels;


public interface IOptionsQuestionModel
{
    public ICollection<QuestionOptionModel> Options { get; init; }
}