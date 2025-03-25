using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Models;


public interface IOptionsQuestionModel
{
    public ICollection<QuestionOptionModel> Options { get; init; }
}