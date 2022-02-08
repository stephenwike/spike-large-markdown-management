namespace DesignDocMarkupLanguage.Constants;

public static class Patterns
{
    public static readonly string TemplatePattern = TemplatePatterns.Pattern;
    public static readonly string DocumentFilesPattern = DocFilesPatterns.Pattern;
    public static readonly string FileTagPattern = FileTagPatterns.Pattern;
}

public static class FileTagPatterns
{
    private static readonly string LINES = @"(?<Lines>[0-9]*,? ?[0-9]*)";
    private static readonly string PATH = @"(?<FilePath>.+)";
    public static readonly string Pattern = $"^{LINES}:?{PATH}";
}

public static class TemplatePatterns
{
    private static readonly string OpenMarkup = @"[\[!:]:";
    private static readonly string CloseMarkup = @":[\]!:]";
    private static readonly string OPEN = $"(?<Open>{OpenMarkup})";
    private static readonly string CLOSE = $"(?<Close>{CloseMarkup})";
    private static readonly string LABEL = $"(?<Label>.+)";
    private static readonly string TABS = @"(?<Tabs>[\t\s]*)";
    private static readonly string HEADER = $"(?<Header>{OPEN}{LABEL}{CLOSE})";
    public static readonly string Pattern = $"^{TABS}{HEADER}";
}

public static class DocFilesPatterns
{
    private static readonly string SpacesOrTabs = @"[\s\t]";
    private static readonly string Period = @"\.";
    private static readonly string Integer = @"[0-9]*";
    private static readonly string NotWordOrPeriod = $"[^A-Za-z0-9{Period}]*";
    private static readonly string WordChars = @"[A-Za-z0-9]";
    private static readonly string SPACE = $"{SpacesOrTabs}*";
    private static readonly string FILENUMBER = $"(?<FileNumber>{Integer} ?-?)";
    private static readonly string PAGE = @"(?<Page>[A-Za-z0-9\(\)\s]+)";
    private static readonly string SUMMARY = $"(?<Summary>{NotWordOrPeriod}{PAGE}{NotWordOrPeriod})";
    private static readonly string EXT = $"(?<Ext>{Period}*{WordChars}*)";
    public static readonly string Pattern = $"^{SPACE}{FILENUMBER}{SPACE}{SUMMARY}{SPACE}{EXT}";
}