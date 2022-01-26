using System.Text;
using System.Text.RegularExpressions;
using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class TemplateParser
{
    private readonly MarkupSettings _settings;
    private readonly StringBuilder _stringBuilder;

    public TemplateParser(MarkupSettings settings)
    {
        _settings = settings;
        _stringBuilder = new StringBuilder();
    }
    
    public string Parse(string template, FileGraph fileGraph)
    {
        var lineCount = 0;
        var activeFileNode = fileGraph.Root.Next(); // Navigate to first node.
        
        using (var reader = new StringReader(template))
        {
            ++lineCount;
            string? line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                Regex regex = new Regex(Patterns.TemplateParserPattern); // TODO: Could be made better to detect what part of the notation is missing.
                var match = regex.Match(line);
                if (match.Success)
                {
                    activeFileNode?.UpdateNode(match, _settings, lineCount);
                    _stringBuilder.AddLines(activeFileNode);
                    activeFileNode = activeFileNode?.Next();
                }
                else
                {
                    _stringBuilder.AppendLine(line);
                }
            }
        }

        return _stringBuilder.ToString();
    }
}