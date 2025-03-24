using System;
using System.Collections.Generic;
using Domain.Entities.Answers;

namespace Domain.Entities;

public class Submission
{
    public Guid Id { get; init; }
    public int FormId { get; init; }
    public Form Form { get; init; }
    public ICollection<AnswerBase> Answers { get; init; }
}