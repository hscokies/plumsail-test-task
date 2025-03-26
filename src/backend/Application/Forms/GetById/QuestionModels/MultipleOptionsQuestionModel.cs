using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Questions;

namespace Application.Forms.GetById.QuestionModels;

public class MultipleOptionsQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(MultipleOptionsQuestion);
    public override string GetDiscriminator() => Discriminator;
    public ICollection<QuestionOptionModel> Options { get; init; }

    public static MultipleOptionsQuestionModel Create(MultipleOptionsQuestion question)
    {
        return new MultipleOptionsQuestionModel
        {
            Id = question.Id,
            Title = question.Title,
            Validator = question.Validator,
            Options = question.Options.Select(QuestionOptionModel.Create).ToArray()
        };
    }
}