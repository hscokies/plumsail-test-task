using System;
using Domain.Entities.Questions;

namespace Domain.Entities.Answers;

public abstract class AnswerBase
{
    public Guid Id { get; init; }
    public string Discriminator { get; init; }
    public Guid SubmissionId { get; init; }
    public Submission Submission { get; init; }
    public int QuestionId { get; init; }
    public QuestionBase Question { get; init; }
}