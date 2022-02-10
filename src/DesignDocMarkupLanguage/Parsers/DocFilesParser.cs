using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Helpers;

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
    
    private static void ParseNodesRecursive(FileGraphNode parentNode)
    {
        if (parentNode?.Directory == null) return;
        
        // For a single node, get all subNodes
        var dirs = parentNode.Directory.GetDirectories()
            .Select(x => new FileGraphNode(parentNode, x)).ToList();
        var files = parentNode.Directory.GetFiles()
            .Select(x => new FileGraphNode(parentNode, x)).ToList();
        parentNode.Children = dirs.Concat(files).ToDictionary(node => node.Value.PageName, node => node);

        foreach (var dir in dirs)
        {
            ParseNodesRecursive(dir);
        }
    }

    public void UpdateFileGraph(string[] template, FileGraph fileGraph) // TODO: Is this still needed?
    {
        // Flag all non-regular markup
        var contextNode = fileGraph.Root;
        for (var index = 0; index < template.Length; ++index)
        {
            var match = new Regex(Patterns.TemplatePattern).Match(template[index]);
            if (match.Success && !string.IsNullOrWhiteSpace(match.Groups["Label"].Value))
            {
                if (match.Groups["Open"].Value == ReservedMarkup.FileOpen)
                {
                    // Update docFiles with IsFileReference flag.
                    contextNode.Value.IsFileReference = true;
                    continue;
                }
                
                var depth = TemplateHelper.GetDepth(match.Groups["Tabs"].Value);
                contextNode = contextNode.Find(match.Groups["Label"].Value, depth);
                if (contextNode == null)
                    throw new IndexOutOfRangeException("Found tag that exceeded the last file/folder in the file docs directory.");
                
                if (match.Groups["Open"].Value == ReservedMarkup.CollapseOpen)
                {
                    // Update docFiles with IsCollapsed flag.
                    contextNode.Value.IsCollapsed = true;

                    // Determine if nested.
                    if (contextNode.Value.IsCollapsed && contextNode?.Parent != null && contextNode.Parent.Value.IsCollapsed)
                    {
                        contextNode.Parent.Value.IsNesting = true;
                    }
                }
            }
        }
    }
}