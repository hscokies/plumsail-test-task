using System;
using System.Collections.Generic;
using Domain.Entities.Questions;

namespace Infrastructure.Persistence.DiscriminatorMappings;

public static class QuestionDiscriminatorMapping
{
    public static readonly IReadOnlyDictionary<string, Type> DiscriminatorMapping = new Dictionary<string, Type>
    {
        [nameof(OpenQuestion)] = typeof(OpenQuestion),
        [nameof(DateQuestion)] = typeof(DateQuestion),
        [nameof(SingleOptionQuestionBase)] = typeof(SingleOptionQuestionBase),
        [nameof(MultipleOptionsQuestionBase)] = typeof(MultipleOptionsQuestionBase),
        [nameof(SelectionQuestionBase)] = typeof(SelectionQuestionBase)
    };

    public static Type GetTypeOrDefault(string discriminator)
    {
        return !DiscriminatorMapping.TryGetValue(discriminator, out var type)
            ? typeof(QuestionBase)
            : type;
    }

    public static T GetInstanceOrDefault<T>(string discriminator) where T : QuestionBase
    {
        var type = GetTypeOrDefault(discriminator);
        return (T)Activator.CreateInstance(type);
    }

    public static bool Is<T>(string discriminator) where T : QuestionBase
    {
        if (!DiscriminatorMapping.TryGetValue(discriminator, out var type))
        {
            throw new InvalidOperationException(
                $"Unable to determine {nameof(QuestionBase)} CLR type for '{discriminator}'.");
        }

        return
            type == typeof(T) ||
            type.IsSubclassOf(typeof(T));
    }
}