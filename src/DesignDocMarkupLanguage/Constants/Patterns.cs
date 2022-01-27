namespace DesignDocMarkupLanguage.Constants;

public static class Patterns
{
    public static readonly string TemplateParserPattern = $"^{TemplatePatterns.TabsGroup}*{TemplatePatterns.HeaderGroup}";
    public static readonly string DocumentFilesPattern = $"^{DocFilesPatterns.FileNumberGroup}{DocFilesPatterns.SummaryGroup}$";
    public static string ReservedMarkup = @"(?<Markup>\[?::\]?)"; // TODO: Better ways to generate.
}

public static class TemplatePatterns
{
    private static readonly string Tags = @"\[:{2}\]";
    private static readonly string WithTags = $"[{Tags}]+";
    private static readonly string NotTag = $"[^{Tags}]";
    private static readonly string TabGroup = @"(?<Tab>[\t\s])";
    private static readonly string PageGroup = $"(?<Page>{NotTag}+)";

    public static readonly string TabsGroup = $"(?<Tabs>{TabGroup}*)";
    public static readonly string HeaderGroup = $"(?<Header>{WithTags}{PageGroup}{WithTags})";
}

public static class DocFilesPatterns
{
    private static readonly string WordsAndSpaces = @"[A-Za-z0-9]+[A-Za-z0-9\s]*";
    private static readonly string NotWord = @"[^A-Za-z0-9]*";
    private static readonly string NotWordAndAfter = $"{NotWord}.*";
    private static readonly string PageGroup = $"(?<Page>{WordsAndSpaces}){NotWordAndAfter}";
    private static readonly string AnyEmptySpace = @"\s*";

    public static readonly string FileNumberGroup = @"(?<FileNumber>[0-9]{2})";
    public static readonly string SummaryGroup = $"{AnyEmptySpace}(?<Summary>{NotWord}{PageGroup}){AnyEmptySpace}";
}