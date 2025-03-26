using System.Text.Json.Serialization;

namespace Application.Submissions.Get.AnswerModels;

[JsonPolymorphic]
[JsonDerivedType(typeof(OpenAnswerModel), nameof(OpenAnswerModel))]
[JsonDerivedType(typeof(DateAnswerModel), nameof(DateAnswerModel))]
[JsonDerivedType(typeof(SingleOptionAnswerModel), nameof(SingleOptionAnswerModel))]
[JsonDerivedType(typeof(MultipleOptionsAnswerModel), nameof(MultipleOptionsAnswerModel))]
public abstract class AnswerModel
{
    public string Question { get; init; }
}