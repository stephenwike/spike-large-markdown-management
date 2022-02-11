using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.CLI;

public static class Settings
{
    public static Uri? TemplateUri { get; set; }
    public static Uri? DocFilesURi { get; set; }
    public static Uri? OutputUri { get; set; }
    public static Uri? RootDir { get; set; }
    public static IndentTypes IndentType { get; set; }
}