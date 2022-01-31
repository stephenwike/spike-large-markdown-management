using System.Text;
using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Extensions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Parsers;

public class TemplateParser
{
    public string Parse(string template, FileGraph fileGraph)
    {
        var activeFileNode = fileGraph.Root.Next(); // Navigate to first node.
        var lineCount = 0;
        return BuildDocument(template, (line, builder) =>
        {
            ++lineCount;
            Regex regex = new Regex(Patterns.TemplateParserPattern);
            var match = regex.Match(line);
            if (match.Success)
            {
                activeFileNode?.UpdateNode(match, lineCount);
                builder.AddLines(activeFileNode);
                activeFileNode = activeFileNode?.Next();
            }
            else
            {
                builder.AppendLine(line);
            }
        });
    }

    public string Enrich(string template, FileGraph fileGraph)
    {
        var activeFileNode = fileGraph.Root.Next(); // Navigate to first node.
        return BuildDocument(template, (line, builder) =>
        {
            var matches = new Regex(Patterns.ReservedMarkup).Matches(line);
            if (matches.Count == 2)
            {
                if (activeFileNode == null) 
                    throw new IndexOutOfRangeException("Found tag that exceeded the last file/folder in the file docs directory.");
                
                builder.AppendLine();
                if (activeFileNode.Value.IsNesting)
                {
                    builder.AppendLine(@"<details>");
                    builder.AppendLine($"<summary>{activeFileNode?.Value.Summary}</summary><blockquote>");
                    builder.AppendLine(line);
                }
                else if (activeFileNode.Value.IsCollapsed)
                {
                    builder.AppendLine(@"<details>");
                    builder.AppendLine($"<summary>{activeFileNode?.Value.Summary}</summary>");
                    builder.AppendLine(line);
                    builder.AppendLine(@"</details>");
                }
                else
                {
                    builder.AppendLine(line);
                }
                
                // Close nested tag if last nested element.
                if (activeFileNode.Value.IsLastNestedElement)
                {
                    builder.AppendLine();
                    builder.AppendLine(@"</blockquote></details>");
                }
                
                builder.AppendLine();
                
                activeFileNode = activeFileNode?.Next();
            }
            else
            {
                builder.AppendLine(line);
            }
        });
    }
    
    private string BuildDocument(string template, Action<string, StringBuilder> act)
    {
        StringBuilder stringBuilder = new StringBuilder();
        using (var reader = new StringReader(template))
        {
            string? line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                act(line, stringBuilder);
            }
        }
        return stringBuilder.ToString();
    }
}