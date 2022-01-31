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

    public void Enrich(FileGraph fileGraph, string template)
    {
        // Flag all non-regular markup
        var activeFileNode = fileGraph.Root.Next();
        using (var reader = new StringReader(template))
        {
            string? line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                var matches = new Regex(Patterns.ReservedMarkup).Matches(line);
                if (matches.Count == 2)
                {
                    if (matches[0].Value == ReservedMarkup.CollapseOpen)
                    {
                        // Update docFiles with IsCollapsed flag.
                        activeFileNode.Value.IsCollapsed = true;
                    }
                    activeFileNode = activeFileNode.Next();
                }
            }
        }
        
        // Flag all nesting markup
        activeFileNode = fileGraph.Root.Next();
        while (activeFileNode != null)
        {
            // If nested collapse tags.
            if (activeFileNode.Value.IsCollapsed &&
                activeFileNode?.Parent != null &&
                activeFileNode.Parent.Value.IsCollapsed)
            {
                activeFileNode.Parent.Value.IsNesting = true;
                
                // If last element in nested collapse tags.
                if (activeFileNode.Parent.Children.Count() == activeFileNode.Value.FileNumber)
                {
                    activeFileNode.Value.IsLastNestedElement = true;
                }
            }
            
            activeFileNode = activeFileNode.Next();
        }
    }
}