using System.Collections.Generic;

namespace Domain.Entities.Questions;

public abstract class OptionsQuestionBase : QuestionBase
{
    public ICollection<QuestionOption> Options { get; set; } = [];
}