using System.Collections.Generic;
using Domain.Entities.Questions;

namespace Application.Forms.Create.QuestionModels;

public class MultipleOptionsQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(MultipleOptionsQuestion);

    public override string GetDiscriminator()
    {
        return Discriminator;
    }

    public ICollection<string> Options { get; init; } = new List<string>();
}