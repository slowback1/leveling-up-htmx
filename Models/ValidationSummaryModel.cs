namespace LevelingUp.HTMX.Models;

public class ValidationSummaryModel
{
    public List<ValidationSummaryField> Fields { get; set; } = new();
    public bool IsValid => Fields.All(f => f.IsValid);
}

public class ValidationSummaryField
{
    public string FieldName { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsValid => ErrorMessage == null;
}