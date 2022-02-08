using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.DataStructs;

public class FileNodeInfo
{
    public FileNodeInfo(string name)
    {
        FullName = name;
        var match = new Regex(Patterns.DocumentFilesPattern).Match(name);
        PageName = match.Groups["Page"].Value;
        Summary = match.Groups["Summary"].Value;
        Ext = match.Groups["Ext"].Value;
    }

    public string Summary { get; set; }
    public string FullName { get; set; }
    public string PageName { get; set; }
    public string Header { get; set; }
    public string Ext { get; set; }

    public bool IsCollapsed { get; set; } = false;
    public bool IsFileReference { get; set; } = false;
    public bool IsNesting { get; set; } = false;
    public bool IsLastNestedElement { get; set; } = false;
}