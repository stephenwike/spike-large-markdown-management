using System.Text;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Extensions;

public static class FileGraphNodeExtensions
{
    public static void AddLines(this StringBuilder builder, FileGraphNode? node)
    {
        if (node == null) throw new Exception(@"Node cannot be null.");
        
        if (!string.IsNullOrWhiteSpace(node.File?.FullName))
        {
            var lines = new List<string>();
            lines.AddRange(File.ReadAllLines(node.File.FullName));
            lines.ForEach(x => builder.AddLine(x));
        }
        else
        {
            var hashes = new string(Enumerable.Repeat('#', node.Depth()).ToArray());
            builder.AddLine($"{hashes} {node.Value.Summary}");
        }
    }

    public static void AddLine(this StringBuilder builder, string line)
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            builder.AppendLine(line);
        }
        else if (builder.Length != 0)
        {
            builder.AppendLine(line);
        }
    }
}