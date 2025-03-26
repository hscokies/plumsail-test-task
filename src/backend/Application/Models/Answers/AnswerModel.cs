using System.Text.Json.Serialization;
using Application.Models.Questions;

namespace Application.Models.Answers;

[JsonPolymorphic]
[JsonDerivedType(typeof(OpenAnswerModel), OpenQuestionModel.Discriminator)]
[JsonDerivedType(typeof(DateAnswerModel), DateQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SelectionAnswerModel), SelectionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SingleOptionAnswerModel), SingleOptionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(MultipleOptionsAnswerModel), MultipleOptionsQuestionModel.Discriminator)]
public abstract class AnswerModel
{
    public int Id { get; set; }
}