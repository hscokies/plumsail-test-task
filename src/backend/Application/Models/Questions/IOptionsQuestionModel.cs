using System.Collections.Generic;

namespace Application.Models.Questions;


public interface IOptionsQuestionModel
{
    public ICollection<QuestionOptionModel> Options { get; init; }
}