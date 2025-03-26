using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Forms.Create.QuestionModels;
using Domain.Entities;
using Domain.Entities.Questions;
using Domain.Enumerations;
using Domain.Primitives;
using Domain.Primitives.Errors;
using Infrastructure.Persistence.DiscriminatorMappings;
using Infrastructure.Persistence.Interfaces;
using NLog;

namespace Application.Forms.Create;

public sealed class CreateFormHandler(IDataContext dataContext) : ICommandHandler<CreateFormCommand, int>
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public async Task<Result<int>> Handle(CreateFormCommand command, CancellationToken ct)
    {
        try
        {
            var formId = await CreateForm(command, ct);
            return formId;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Failed to create form: {message}", e.Message);
            return Error.Failure("Form.Unknown", "Unhandled exception while creating form.");
        }
    }

    private async Task<int> CreateForm(CreateFormCommand command, CancellationToken ct)
    {
        var form = BuildForm(command);
        dataContext.Forms.Add(form);
        await dataContext.SaveChangesAsync(ct);
        return form.Id;
    }
    private static Form BuildForm(CreateFormCommand command)
    {
        var form = new Form
        {
            Title = command.Title,
            Subtitle = command.Subtitle,
            Color = command.Color,
        };

        foreach (var questionBase in CreateQuestions(command))
        {
            form.Questions.Add(questionBase);
        }
        
        return form;
    }

    private static IEnumerable<QuestionBase> CreateQuestions(CreateFormCommand command)
    {
        foreach (var questionModel in command.Questions)
        {
            var discriminator = questionModel.GetDiscriminator();
            var question = QuestionDiscriminatorMapping.GetInstanceOrDefault<QuestionBase>(discriminator);
            question.Title = questionModel.Title;
            question.Validator = questionModel.Validator ?? QuestionValidators.None;

            switch (question)
            {
                case OptionsQuestionBase optionsQuestion:
                    optionsQuestion.Options = ((IOptionsQuestionModel)questionModel).Options
                        .Select(x => new QuestionOption
                        {
                            Value = x
                        }).ToArray();
                    break;
                case IQuestionWithPlaceholder questionWithPlaceholder:
                    questionWithPlaceholder.Placeholder = ((IPlaceholderQuestion)questionModel).Placeholder;
                    break;
            }

            yield return question;
        }
    }
}