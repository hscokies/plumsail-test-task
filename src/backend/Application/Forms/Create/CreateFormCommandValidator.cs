using Application.Models.Questions;
using Domain.Entities.Questions;
using Domain.Enumerations;
using FluentValidation;
using Infrastructure.Persistence.DiscriminatorMappings;

namespace Application.Forms.Create;

public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
{
    public CreateFormCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(x => x.Subtitle)
            .NotEmpty()
            .MaximumLength(512); 

        RuleFor(x => x.Color).MaximumLength(7);

        RuleFor(x => x.Questions)
            .NotEmpty()
            .ForEach(x => x
                .Must(q => QuestionDiscriminatorMapping.DiscriminatorMapping.ContainsKey(q.GetDiscriminator()))
                .WithMessage("Unknown question discriminator")

                .Must(q => q.Validator is null || QuestionValidators.HashSet.Contains(q.Validator))
                .WithMessage("Unknown question validator")
            
                .Must(q =>
                {
                    if (QuestionDiscriminatorMapping.Is<OptionsQuestionBase>(q.GetDiscriminator()))
                    {
                        return ((IOptionsQuestionModel)q).Options.Count > 1;
                    }
                    return true;
                })
                .WithMessage("Options question should contain at least 2 options"));
    }
}