using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Questions;

namespace Application.Forms.GetById.QuestionModels;

public class SingleOptionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SingleOptionQuestion);
    public override string GetDiscriminator() => Discriminator;
    public ICollection<QuestionOptionModel> Options { get; init; }

    public static SingleOptionQuestionModel Create(SingleOptionQuestion question)
    {
        return new SingleOptionQuestionModel
        {
            Id = question.Id,
            Title = question.Title,
            Validator = question.Validator,
            Options = question.Options.Select(QuestionOptionModel.Create).ToArray()
        };
    }
}