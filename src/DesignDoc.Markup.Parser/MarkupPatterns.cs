namespace DesignDoc.Markup.Parser;

public static class MarkupPatterns
{
    private static readonly string Tag = @"::";
    private static readonly string NotTag = $"[^{Tag}]";
    private static readonly string TabGroup = @"(?<Tabs>[\t\s]*)"; // TODO: Modify for support for spaces too. Like : @"(?<Tab>[\t\s*])" I think...
    private static readonly string PageGroup = $"(?<Page>{NotTag}+)";
    private static readonly string HeaderGroup = $"(?<Header>{Tag}{PageGroup}{Tag})";
    
    public static readonly string TemplateParserPattern = $"^{TabGroup}{HeaderGroup}";
}