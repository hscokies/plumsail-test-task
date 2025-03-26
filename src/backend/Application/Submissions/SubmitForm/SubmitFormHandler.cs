using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Models.Answers;
using Domain.Entities;
using Domain.Entities.Answers;
using Domain.Entities.Questions;
using Domain.Errors;
using Domain.Primitives;
using Domain.Primitives.Errors;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Submissions.SubmitForm;

/*
 TODO: Backend should probably use same validations as frontend
    but this was not specified in test task, so let's keep it as is
 */
public sealed class SubmitFormHandler(IDataContext dataContext) : ICommandHandler<SubmitFormCommand, Guid>
{
    public async Task<Result<Guid>> Handle(SubmitFormCommand command, CancellationToken ct)
    {
        var form = await GetForm(command, ct);
        if (form is null)
        {
            return FormErrors.NotFound(command.FormId);
        }

        var result = BuildSubmission(form, command);
        if (result.IsFailure)
        {
            return result.Error;
        }

        dataContext.Submissions.Add(result.Value);
        await dataContext.SaveChangesAsync(ct);
        return result.Value.Id;
    }

    private Task<Form> GetForm(SubmitFormCommand command, CancellationToken ct)
    {
        return dataContext.Forms.Include(x => x.Questions)
            .ThenInclude(x => (x as OptionsQuestionBase).Options)
            .FirstOrDefaultAsync(x => x.Id == command.FormId, ct);
    }

    private static Result<Submission> BuildSubmission(Form form, SubmitFormCommand command)
    {
        var submission = new Submission
        {
            Id = Guid.NewGuid(),
            FormId = command.FormId
        };

        var errors = new List<Error>();
        foreach (var question in form.Questions)
        {
            var answer = command.Answers.FirstOrDefault(x => x.Id == question.Id);
            if (answer is null)
            {
                errors.Add(AnswerErrors.QuestionNotFound(question.Id));
                continue;
            }

            switch (question)
            {
                case OptionsQuestionBase optionsQuestion:
                    HandleOptionsQuestion(optionsQuestion, answer, submission, errors);
                    break;
                case OpenQuestion when answer is OpenAnswerModel openAnswer:
                    submission.Answers.Add(new OpenAnswer
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        Value = openAnswer.Value
                    });
                    break;
                case DateQuestion when answer is DateAnswerModel dateAnswer:
                    submission.Answers.Add(new DateAnswer
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        Value = dateAnswer.Value
                    });
                    break;
            }
        }

        return errors.Count > 0
            ? new ValidationError(errors)
            : submission;
    }

    private static void HandleOptionsQuestion(
        OptionsQuestionBase optionsQuestion,
        AnswerModel answer,
        Submission submission,
        List<Error> errors)
    {
        switch (answer)
        {
            case ISingleOptionAnswer singleOptionAnswer:
            {
                var option = optionsQuestion.Options.FirstOrDefault(x => x.Id == singleOptionAnswer.Value);
                if (option is null)
                {
                    errors.Add(AnswerErrors.OptionNotFound(answer.Id, singleOptionAnswer.Value));
                    return;
                }

                submission.Answers.Add(new OptionAnswer
                {
                    Id = Guid.NewGuid(),
                    QuestionId = optionsQuestion.Id,
                    OptionId = singleOptionAnswer.Value
                });
                return;
            }
            case MultipleOptionsAnswerModel multipleOptionAnswer:
            {
                foreach (var optionId in multipleOptionAnswer.Value)
                {
                    var option = optionsQuestion.Options.FirstOrDefault(x => x.Id == optionId);
                    if (option is null)
                    {
                        errors.Add(AnswerErrors.OptionNotFound(answer.Id, optionId));
                        continue;
                    }

                    submission.Answers.Add(new OptionAnswer
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = optionsQuestion.Id,
                        OptionId = optionId
                    });
                }

                break;
            }
        }
    }
}