using System.Collections.Generic;
using Domain.Entities.Questions;

namespace Domain.Entities;

public class Form
{
    public int Id { get; init; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Color { get; set; }
    public ICollection<QuestionBase> Questions { get; init; } = [];
    public ICollection<Submission> Submissions { get; init; } = [];
}