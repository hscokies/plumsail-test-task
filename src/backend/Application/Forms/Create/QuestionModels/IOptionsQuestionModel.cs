using System.Collections.Generic;

namespace Application.Forms.Create.QuestionModels;

public interface IOptionsQuestionModel
{
    public ICollection<string> Options { get; init; }
}