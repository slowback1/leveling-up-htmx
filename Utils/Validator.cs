using LevelingUp.HTMX.Models;

namespace LevelingUp.HTMX.Utils;

public class Validator
{
    public ValidationSummaryModel Validate(IFormCollection formCollection)
    {
        var name = GetValue(formCollection, "name");
        var email = GetValue(formCollection, "email");
        var password = GetValue(formCollection, "password");

        var summary = new ValidationSummaryModel();

        summary.Fields.Add(ValidateRequiredField(name, "name"));
        summary.Fields.Add(ValidateRequiredField(email, "email"));

        return summary;
    }

    private ValidationSummaryField ValidateRequiredField(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new ValidationSummaryField
            {
                FieldName = fieldName,
                ErrorMessage = $"{fieldName} is required"
            };
        return new ValidationSummaryField
        {
            FieldName = fieldName
        };
    }

    private string GetValue(IFormCollection formCollection, string key)
    {
        if (formCollection.ContainsKey(key))
            return (string?)formCollection[key] ?? "";
        return "";
    }
}