using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Domain.Enumerations;

public static class QuestionValidators
{
    public const string None = "none";
    public const string Default = "default";
    public const string Text = "text";
    public const string Date = "date";
    public const string Email = "email";
    public const string Birthdate = "birthdate";
    public const string Radio = "radio";
    public const string Checkbox = "checkbox";

    public static readonly HashSet<string> HashSet = typeof(QuestionValidators)
        .GetFields(BindingFlags.Static | BindingFlags.Public)
        .Select(x => (string) x.GetValue(null))
        .ToHashSet();
}