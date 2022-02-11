using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.Models;

public class TemplateStep
{
    public int Depth { get; init; }
    public TemplateAction Action { get; init; }
    public string Id { get; set; } = string.Empty;
    public int Index { get; init; }
    public string Label { get; init; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public bool HasContent { get; set; } = false;
    public int Line { get; init; }
    public string[]? AllLines { get; set; }
}