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
}