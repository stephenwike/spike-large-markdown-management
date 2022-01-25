using System.Text.RegularExpressions;

namespace DesignDoc.Markup.Parser.DataStructs;

public static class FileGraphNodeExtensions
{
    public static void ParseNodesRecursive(this FileGraphNode node)
    {
        if (node?.Directory == null) return;
        
        // For a single node, get all subNodes
        var dirs = node.Directory.GetDirectories()
            .Where(x => new Regex(MarkupPatterns.DocumentFilesPattern).IsMatch(x.Name))
            .Select(x => new FileGraphNode(node, x)).OrderBy(x => x.Value.FileNumber).ToList();
        var files = node.Directory.GetFiles()
            .Where(x => new Regex(MarkupPatterns.DocumentFilesPattern).IsMatch(x.Name))
            .Select(x => new FileGraphNode(node, x)).ToList();
        node.Children = dirs.Union(files).OrderBy(x => x.Value.FileNumber).ToList();

        foreach (var dir in dirs)
        {
            dir.ParseNodesRecursive();
        }
    }

    public static void UpdateNode(this FileGraphNode node, Match match, MarkupSettings settings, int lineCount)
    {
        var header = match.Groups["Header"].Value ?? throw new Exception("Null Header Group");
        var page = match.Groups["Page"].Value ?? throw new Exception("Null Page Group");
        var tabs = (match.Groups["Tabs"]?.Captures.Count ?? 0) / (int)settings.IndentType;
        
        if (node.Value.PageName != page) 
            throw new Exception($"Expected {node.Value.PageName} and got {page} on line {lineCount}.");
        if (node.Depth() != tabs)
            throw new Exception($"Expected {node.Depth()} indents and got {tabs} on line {lineCount}.");
        node.Value.Header = header;
    }
}