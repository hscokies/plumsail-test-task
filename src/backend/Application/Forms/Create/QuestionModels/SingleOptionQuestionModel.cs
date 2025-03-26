using System.Collections.Generic;
using Domain.Entities.Questions;

namespace Application.Forms.Create.QuestionModels;

public class SingleOptionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SingleOptionQuestion);

    public override string GetDiscriminator()
    {
        return Discriminator;
    }

    public ICollection<string> Options { get; init; } = new List<string>();
}