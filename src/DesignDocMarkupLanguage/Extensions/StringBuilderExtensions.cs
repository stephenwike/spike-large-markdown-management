using System.Text;

namespace DesignDocMarkupLanguage.Extensions;

public static class FileGraphNodeExtensions
{
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