namespace DesignDoc.Markup.Parser.DataStructs;

public class FileGraphNode
{
    public FileGraphNode(FileGraphNode? parent, DirectoryInfo di) : this(parent, di.Name)
    { Directory = di; }
    public FileGraphNode(FileGraphNode? parent, FileInfo fi) : this(parent, fi.Name) {}
    private FileGraphNode(FileGraphNode? parent, string name)
    {
        Parent = parent;
        Value = new FileNodeInfo(name);
    }
    public FileNodeInfo Value { get; set; }
    public List<FileGraphNode>? Children { get; set; }
    public FileGraphNode? Parent { get; set; }
    public DirectoryInfo? Directory { get; set; }

    public FileGraphNode? Next() // TODO: Overload ++ instead?
    {
        return NextRecursive(this, 0);
    }

    private FileGraphNode? NextRecursive(FileGraphNode node, int lastChildVisitedIndex)
    {
        // Return first child not visited.
        if (node.Children != null && node.Children.Count < node.Value.FileNumber) 
            return node.Children[node.Value.FileNumber];
        
        // Return null if node doesn't have younger siblings and is root node.
        if (node.Parent == null) return null;

        // Set node to parent node and call next again.
        return NextRecursive(node.Parent, node.Value.FileNumber);
    }

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
}