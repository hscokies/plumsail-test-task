using System;
using System.Text.Json.Serialization;
using Domain.Entities.Questions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Models;

[JsonPolymorphic]
[JsonDerivedType(typeof(OpenQuestionModel), OpenQuestionModel.Discriminator)]
[JsonDerivedType(typeof(DateQuestionModel), DateQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SelectionQuestionModel), SelectionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SingleOptionQuestionModel), SingleOptionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(MultipleOptionsQuestionModel), MultipleOptionsQuestionModel.Discriminator)]
public abstract class QuestionModel
{
    public int Id { get; init; }
    public string Key { get; init; }
    public string Title { get; set; }
    public string Validator { get; init; }

    public abstract string GetDiscriminator();
}