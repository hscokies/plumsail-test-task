using System;
using System.Collections.Generic;
using Application.Abstractions;
using Application.Submissions.Create.AnswerModels;

namespace Application.Submissions.Create;

public record CreateSubmissionCommand(int FormId, ICollection<AnswerModel> Answers) : ICommand<Guid>
{
    public static string Path => "/api/submissions";
}