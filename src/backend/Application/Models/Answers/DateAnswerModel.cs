using System;

namespace Application.Models.Answers;

public class DateAnswerModel : AnswerModel
{
    public DateOnly Value { get; set; }
}