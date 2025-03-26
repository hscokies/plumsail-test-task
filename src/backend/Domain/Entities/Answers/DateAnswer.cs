using System;

namespace Domain.Entities.Answers;

public class DateAnswer : AnswerBase
{
    public DateOnly Value { get; init; }
}