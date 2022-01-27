using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Parsers;

public class DocFilesParser
{
    public FileGraph Parse(Uri docFiles)
    {
        var di = new DirectoryInfo(docFiles.LocalPath);
        var graph = new FileGraph(di);

        ParseNodesRecursive(graph.Root);
        return graph;
    }
    
    private static void ParseNodesRecursive(FileGraphNode node)
    {
        if (node?.Directory == null) return;
        
        // For a single node, get all subNodes
        var dirs = node.Directory.GetDirectories()
            .Where(x => new Regex(Patterns.DocumentFilesPattern).IsMatch(x.Name))
            .Select(x => new FileGraphNode(node, x)).OrderBy(x => x.Value.FileNumber).ToList();
        var files = node.Directory.GetFiles()
            .Where(x => new Regex(Patterns.DocumentFilesPattern).IsMatch(x.Name))
            .Select(x => new FileGraphNode(node, x)).ToList();
        node.Children = dirs.Union(files).OrderBy(x => x.Value.FileNumber).ToList();

        foreach (var dir in dirs)
        {
            ParseNodesRecursive(dir);
        }
    }
}