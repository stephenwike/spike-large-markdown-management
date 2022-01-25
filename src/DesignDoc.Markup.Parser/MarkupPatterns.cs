namespace DesignDoc.Markup.Parser;

public static class MarkupPatterns
{
    private static readonly string Tag = @"::";
    private static readonly string NotTag = $"[^{Tag}]";
    private static readonly string TabGroup = @"(?<Tab>[\t\s])";
    private static readonly string TabsGroup = $"(?<Tabs>{TabGroup}*";
    private static readonly string PageGroup = $"(?<Page>{NotTag}+)";
    private static readonly string HeaderGroup = $"(?<Header>{Tag}{PageGroup}{Tag})";
    
    public static readonly string TemplateParserPattern = $"^{TabsGroup}*{HeaderGroup}";
    public static string DocumentFilesPattern { get; set; } // TODO: Actually make this.
}