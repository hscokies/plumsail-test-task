using System;
using System.Collections.Generic;
using Application.Submissions.Get.AnswerModels;

namespace Application.Submissions.Get;

public class GetSubmissionsResponse : List<GetSubmissionModel>;

public record GetSubmissionModel(
    Guid Id,
    int FormId,
    string Title,
    string Subtitle,
    string Color)
{
    public ICollection<AnswerModel> Answers { get; } = new List<AnswerModel>();
}