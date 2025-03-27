using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Submissions.Create.AnswerModels;
using Domain.Entities;
using Domain.Entities.Answers;
using Domain.Entities.Questions;
using Domain.Enumerations;
using Domain.Errors;
using Domain.Primitives;
using Domain.Primitives.Errors;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Submissions.Create;

/*
TODO:
In perfect world, handler should have same validations as frontend, but this is just an MVP so no validations here
 */
public sealed class CreateSubmissionHandler(IDataContext dataContext) : ICommandHandler<CreateSubmissionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateSubmissionCommand command, CancellationToken ct)
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

    private Task<Form> GetForm(CreateSubmissionCommand command, CancellationToken ct)
    {
        return dataContext.Forms.Include(x => x.Questions)
            .ThenInclude(x => (x as OptionsQuestionBase).Options)
            .FirstOrDefaultAsync(x => x.Id == command.FormId, ct);
    }

    private static Result<Submission> BuildSubmission(Form form, CreateSubmissionCommand command)
    {
        var submission = new Submission
        {
            Id = Guid.NewGuid(),
            FormId = command.FormId
        };

        var errors = new List<Error>();
        foreach (var question in form.Questions)
        {
            var answer = command.Answers.FirstOrDefault(x => x.QuestionId == question.Id);
            if (answer is null && question.Validator is not QuestionValidators.None)
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
                    errors.Add(AnswerErrors.OptionNotFound(answer.QuestionId, singleOptionAnswer.Value));
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
                        errors.Add(AnswerErrors.OptionNotFound(answer.QuestionId, optionId));
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