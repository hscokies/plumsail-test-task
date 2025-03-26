using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Questions;

namespace Application.Forms.GetById.QuestionModels;

public class SelectionQuestionModel : QuestionModel, IOptionsQuestionModel
{
    public const string Discriminator = nameof(SelectionQuestion);
    public override string GetDiscriminator() => Discriminator;
    public string Placeholder { get; init; }
    public ICollection<QuestionOptionModel> Options { get; init; }

    public static SelectionQuestionModel Create(SelectionQuestion question)
    {
        return new SelectionQuestionModel
        {
            Id = question.Id,
            Placeholder = question.Placeholder,
            Title = question.Title,
            Validator = question.Validator,
            Options = question.Options.Select(QuestionOptionModel.Create).ToArray()
        };
    }
}