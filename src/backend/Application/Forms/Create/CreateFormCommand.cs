using System.Collections.Generic;
using Application.Abstractions;
using Application.Models.Questions;

namespace Application.Forms.Create;

public record CreateFormCommand(
    string Title,
    string Subtitle,
    string Color) : ICommand<int>
{
    public static string Path => "/api/forms";
    public ICollection<QuestionModel> Questions { get; set; } = new List<QuestionModel>();
}