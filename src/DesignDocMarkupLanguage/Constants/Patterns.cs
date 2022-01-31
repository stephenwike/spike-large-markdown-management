namespace DesignDocMarkupLanguage.Constants;

public static class Patterns
{
    public static readonly string TemplateParserPattern = $"^{TemplatePatterns.TabsGroup}*{TemplatePatterns.HeaderGroup}";
    public static readonly string DocumentFilesPattern = $"^{DocFilesPatterns.Pattern}";
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
    private static readonly string SpacesOrTabs = @"[\s\t]";
    private static readonly string Period = @"\.";
    private static readonly string ZeroOrMany = @"*";
    private static readonly string OneOrMany = @"+";
    private static readonly string Integer = @"[0-9]" + OneOrMany;
    private static readonly string NotWordOrPeriod = $"[^A-Za-z0-9{Period}]{ZeroOrMany}";
    private static readonly string WordChars = @"[A-Za-z0-9]";
    private static readonly string WordCharsAndSpaces = @"[A-Za-z0-9\s]";

    private static readonly string SPACE = $"{SpacesOrTabs}{ZeroOrMany}";
    private static readonly string WORDS = $"{WordCharsAndSpaces}{OneOrMany}";
    private static readonly string FILENUMBER = $"(?<FileNumber>{Integer})";
    private static readonly string PAGE = $"(?<Page>{WORDS})";
    private static readonly string SUMMARY = $"(?<Summary>{NotWordOrPeriod}{PAGE}{NotWordOrPeriod})";
    private static readonly string EXT = $"{Period}{ZeroOrMany}{WordChars}{ZeroOrMany}";
    
    public static readonly string Pattern = $"{SPACE}{FILENUMBER}{SPACE}{SUMMARY}{SPACE}{EXT}";
}