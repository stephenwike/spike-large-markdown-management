using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.DataStructs;

public class FileNodeInfo
{
    public FileNodeInfo(string name) // TODO: This should be a model and not contain business logic.
    {
        FullName = name;
        var match = new Regex(Patterns.DocumentFilesPattern).Match(name);
        PageName = match.Groups["Page"].Value;
        Summary = match.Groups["Summary"].Value;
        Extension = match.Groups["Extension"].Value;
    }

    public string Summary { get; set; }
    public string FullName { get; set; }
    public string PageName { get; set; }
    public string Extension { get; set; }
}