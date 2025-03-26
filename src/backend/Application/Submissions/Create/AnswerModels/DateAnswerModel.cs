using System;

namespace Application.Submissions.Create.AnswerModels;

public class DateAnswerModel : AnswerModel
{
    public DateOnly Value { get; set; }
}