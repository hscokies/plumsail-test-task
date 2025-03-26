using System;
using Application.Forms.GetById.QuestionModels;
using Domain.Entities.Questions;

namespace Application.Forms.GetById.Factories;

internal static class QuestionModelFactory
{
    public static QuestionModel ToQuestionModel(this QuestionBase question) =>
        question switch
        {
            DateQuestion dateQuestion => DateQuestionModel.Create(dateQuestion),
            MultipleOptionsQuestion multipleOptionsQuestion => MultipleOptionsQuestionModel.Create(
                multipleOptionsQuestion),
            OpenQuestion openQuestion => OpenQuestionModel.Create(openQuestion),
            SelectionQuestion selectionQuestion => SelectionQuestionModel.Create(selectionQuestion),
            SingleOptionQuestion singleOptionQuestion => SingleOptionQuestionModel.Create(singleOptionQuestion),
            _ => throw new ArgumentOutOfRangeException(nameof(question), question, null)
        };
}