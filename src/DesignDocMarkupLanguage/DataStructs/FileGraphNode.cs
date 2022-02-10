namespace DesignDocMarkupLanguage.DataStructs;

public class FileGraphNode
{
    public FileGraphNode(FileGraphNode? parent, DirectoryInfo di)
    { Parent = parent; Directory = di; Value = new FileNodeInfo(di.Name); }
    public FileGraphNode(FileGraphNode? parent, FileInfo fi)
    { Parent = parent; File = fi; Value = new FileNodeInfo(fi.Name);}
    
    public FileNodeInfo Value { get; set; }
    public Dictionary<string, FileGraphNode>? Children { get; set; }
    public FileGraphNode? Parent { get; set; }
    public DirectoryInfo? Directory { get; set; }
    public FileInfo? File { get; set; }

    public int Depth()
    {
        var depth = 0;
        var node = this.Parent;
        while (node != null)
        {
            ++depth;
            node = node.Parent;
        }
        return depth;
    }

    public FileGraphNode? Find(string value, int depth)
    {        
        var thisDepth = Depth();

        // If higher, find in parent. 
        if (depth < thisDepth && Parent != null)
            return Parent.Find(value, depth);
        
        // If lower, get child.
        if (depth > thisDepth && Children != null && Children.ContainsKey(value))
            return Children[value];
        
        // If equal, get Sibling.
        if (depth == thisDepth && Parent?.Children != null && Parent.Children.ContainsKey(value))
            return Parent.Children[value];

        // Else return null.
        return null;
    }
}