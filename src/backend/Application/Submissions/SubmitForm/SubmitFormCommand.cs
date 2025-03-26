using System;
using System.Collections.Generic;
using Application.Abstractions;
using Application.Models.Answers;

namespace Application.Submissions.SubmitForm;

public record SubmitFormCommand(int FormId, ICollection<AnswerModel> Answers) : ICommand<Guid>
{
    public static string Path => "/submissions";
}