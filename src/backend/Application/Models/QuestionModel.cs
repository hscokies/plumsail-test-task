using System;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Models;

[JsonPolymorphic]
[JsonDerivedType(typeof(OpenQuestionModel), "OpenQuestion")]
[JsonDerivedType(typeof(DateQuestionModel), "DateQuestion")]
[JsonDerivedType(typeof(SelectionQuestionModel), "SelectionQuestions")]
[JsonDerivedType(typeof(SingleOptionQuestionModel), "SingleOptionQuestion")]
[JsonDerivedType(typeof(MultipleOptionsQuestionModel), "MultipleOptionsQuestion")]
public abstract class QuestionModel
{
    public int Id { get; init; }
    public string Title { get; set; }
    public string Validator { get; init; }
}