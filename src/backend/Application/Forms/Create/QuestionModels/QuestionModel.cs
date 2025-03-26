using System.Text.Json.Serialization;

namespace Application.Forms.Create.QuestionModels;

[JsonPolymorphic]
[JsonDerivedType(typeof(OpenQuestionModel), OpenQuestionModel.Discriminator)]
[JsonDerivedType(typeof(DateQuestionModel), DateQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SelectionQuestionModel), SelectionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(SingleOptionQuestionModel), SingleOptionQuestionModel.Discriminator)]
[JsonDerivedType(typeof(MultipleOptionsQuestionModel), MultipleOptionsQuestionModel.Discriminator)]
public abstract class QuestionModel
{
    public string Title { get; set; }
    public string Validator { get; init; }
    public abstract string GetDiscriminator();
}