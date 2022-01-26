using System.Text.RegularExpressions;

namespace DesignDoc.Markup.Parser;

public class FileNodeInfo
{
    public FileNodeInfo(string name)
    {
        FullName = name;
        var match = new Regex(Patterns.DocumentFilesPattern).Match(name);
        FileNumber = int.Parse(match.Groups["FileNumber"].Value);
        PageName = match.Groups["Page"].Value;
        Summary = match.Groups["Summary"].Value;
    }

    public string Summary { get; set; }
    public string FullName { get; set; }
    public int FileNumber { get; set; }
    public string PageName { get; set; }
    public string Header { get; set; }
}