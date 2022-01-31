using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.CLI;

namespace DesignDocMarkupLanguage.DataStructs;

public static class FileGraphNodeExtensions
{
    public static void UpdateNode(this FileGraphNode node, Match match, int lineCount)
    {
        var header = match.Groups["Header"].Value ?? throw new Exception("Null Header Group");
        var page = match.Groups["Page"].Value ?? throw new Exception("Null Page Group");
        var tabs = (match.Groups["Tab"]?.Captures.Count ?? 0) / (int) Settings.IndentType;
        
        if (node.Value.PageName.ToLower() != page.ToLower()) 
            throw new Exception($"Expected {node.Value.PageName} and got {page} on line {lineCount}.");
        if (node.Depth() - 1 != tabs)
            throw new Exception($"Expected {node.Depth() - 1} indents and got {tabs} on line {lineCount}.");
        node.Value.Header = header;
    }
}