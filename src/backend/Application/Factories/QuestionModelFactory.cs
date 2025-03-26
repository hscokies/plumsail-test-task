using System;
using Application.Models.Questions;
using Domain.Entities.Questions;

namespace Application.Factories;

internal static class QuestionModelFactory
{
    public static QuestionModel ToQuestionModel(this QuestionBase question) =>
        question switch
        {
            DateQuestion => (DateQuestionModel)question,
            MultipleOptionsQuestion => (MultipleOptionsQuestionModel)question,
            OpenQuestion => (OpenQuestionModel)question,
            SelectionQuestion => (SelectionQuestionModel)question,
            SingleOptionQuestion => (SingleOptionQuestionModel)question,
            _ => throw new ArgumentOutOfRangeException(nameof(question), question, null)
        };

}