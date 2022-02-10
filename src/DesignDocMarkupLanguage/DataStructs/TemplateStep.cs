using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.Models;

namespace DesignDocMarkupLanguage.DataStructs;

public class TemplateStep
{
    public int Depth { get; set; }
    public TemplateAction Action { get; set; }
    public string Id { get; set; }
    public int Line { get; set; }
    public string Label { get; set; }
    public string Path { get; set; }
    public string Summary { get; set; }
    public bool HasContent { get; set; } = false;
    public FileReference? FileRef { get; set; }
}