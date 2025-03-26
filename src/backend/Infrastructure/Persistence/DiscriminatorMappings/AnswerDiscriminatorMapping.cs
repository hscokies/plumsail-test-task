using System;
using System.Collections.Generic;
using Domain.Entities.Answers;

namespace Infrastructure.Persistence.DiscriminatorMappings;

public static class AnswerDiscriminatorMapping
{
    public static readonly IReadOnlyDictionary<string, Type> DiscriminatorMapping = new Dictionary<string, Type>
    {
        [nameof(OpenAnswer)] = typeof(OpenAnswer),
        [nameof(OptionAnswer)] = typeof(OptionAnswer),
        [nameof(DateAnswer)] = typeof(DateAnswer)
    };

    public static Type GetTypeOrDefault(string discriminator)
    {
        return !DiscriminatorMapping.TryGetValue(discriminator, out var type)
            ? typeof(AnswerBase)
            : type;
    }

    public static T GetInstanceOrDefault<T>(string discriminator) where T : AnswerBase
    {
        var type = GetTypeOrDefault(discriminator);
        return (T)Activator.CreateInstance(type);
    }

    public static bool Is<T>(string discriminator) where T : AnswerBase
    {
        if (!DiscriminatorMapping.TryGetValue(discriminator, out var type))
        {
            throw new InvalidOperationException(
                $"Unable to determine {nameof(AnswerBase)} CLR type for '{discriminator}'.");
        }

        return
            type == typeof(T) ||
            type.IsSubclassOf(typeof(T));
    }
}