namespace DesignDocMarkupLanguage.DataStructs;

public class FileGraphNode
{
    public FileGraphNode(FileGraphNode parent, DirectoryInfo di)
    { Parent = parent; Directory = di; Value = new FileNodeInfo(di.Name); }
    public FileGraphNode(FileGraphNode parent, FileInfo fi)
    { Parent = parent; File = fi; Value = new FileNodeInfo(fi.Name);}
    public FileGraphNode(DirectoryInfo di)
    {
        // Constructor for root node.
        // Root directory shouldn't have to start with numbers.
        Directory = di;
        Value = new FileNodeInfo($"01 {di.Name}");
    }
    
    public FileNodeInfo Value { get; set; }
    public List<FileGraphNode>? Children { get; set; }
    public FileGraphNode? Parent { get; set; }
    public DirectoryInfo? Directory { get; set; }
    public FileInfo? File { get; set; }

    public FileGraphNode? Next() // TODO: Overload ++ instead?
    {
        return NextRecursive(this, 0);
    }

    private FileGraphNode? NextRecursive(FileGraphNode node, int lastChildVisitedIndex)
    {
        // Return first child not visited.
        if (node.Children != null && lastChildVisitedIndex < node.Children.Count)
            return node.Children[lastChildVisitedIndex];
        
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