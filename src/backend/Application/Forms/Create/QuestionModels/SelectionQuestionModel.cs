using System.Collections.Generic;
using Domain.Entities.Questions;

namespace Application.Forms.Create.QuestionModels;

public class SelectionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SelectionQuestion);

    public override string GetDiscriminator()
    {
        return Discriminator;
    }

    public string Placeholder { get; init; }
    public ICollection<string> Options { get; init; } = new List<string>();
}