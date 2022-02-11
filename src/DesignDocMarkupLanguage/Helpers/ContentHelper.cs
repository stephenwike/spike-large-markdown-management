using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.Helpers;

public static class ContentHelper
{
    public static string[] GetContent(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new Exception("Path cannot be null or empty.");
        if (Settings.RootDir?.LocalPath == null)
            throw new SystemException("Root directory Uri should not be null, failed to catch error in validator.");
        
        var filePath = Path.GetFullPath(Path.Combine(Settings.RootDir.LocalPath, path));
        if (!File.Exists(Path.Combine(Settings.RootDir.LocalPath, path)))
            throw new Exception($"File {path} not found in path {Settings.RootDir.LocalPath}");

        var lines = File.ReadAllLines(filePath);

        return AddFileReferenceContent(lines);
    }

    private static string[] AddFileReferenceContent(string[] lines)
    {
        var addLines = new List<string>();
        
        for (var index = 0; index < lines.Length; ++index)
        {
            var match = new Regex(Patterns.FileReferencePattern).Match(lines[index]);
            if (match.Success)
            {
                if (Settings.RootDir?.LocalPath == null)
                    throw new SystemException("Root directory Uri should not be null, failed to catch error in validator.");
                var filePath = Path.GetFullPath(Path.Combine(Settings.RootDir.LocalPath, match.Groups["FilePath"].Value));
                if (!File.Exists(filePath))
                {
                    throw new Exception($"Could not find file reference {filePath}. Make sure the path is relative to where the tool is run.");
                }
                {
                    var lineOptions = match.Groups["Lines"].Value;
                    var options = lineOptions.Split(',');
                    var start = (string.IsNullOrWhiteSpace(options[0])) ? 0 : int.Parse(options[0]) - 1;
                    var length = (options.Length == 2) ? int.Parse(options[1]) - start : -1;
                        
                    var fileLines = File.ReadAllLines(filePath).Skip(start);
                    if (length >= 0) { fileLines = fileLines.Take(length); }
                        
                    addLines.Add(@"```csharp"); // TODO:  Should be dynamic based on extension.
                    addLines.AddRange(fileLines);
                    addLines.Add(@"```");
                }
            }
            else
            {
                addLines.Add(lines[index]);
            }
        }
        
        return addLines.ToArray();
    }
}