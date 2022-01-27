using System.Text;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Extensions;

public static class FileGraphNodeExtensions
{
    public static void AddLines(this StringBuilder builder, FileGraphNode? node)
    {
        if (node == null) throw new Exception($"Node cannot be null.");
        
        var lines = new List<string>();
        if (!string.IsNullOrWhiteSpace(node.File?.FullName))
            lines.AddRange(File.ReadAllLines(node.File.FullName));
        
        builder.AppendLine(); // Add Newline
        lines.ForEach(x => builder.AppendLine(x));
        builder.AppendLine(); // Add Newline
    }
}