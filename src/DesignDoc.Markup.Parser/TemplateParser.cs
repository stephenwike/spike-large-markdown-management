using System.Text;
using System.Text.RegularExpressions;
using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class TemplateParser
{
    private readonly MarkupSettings _settings;
    private StringBuilder _stringBuilder;

    public TemplateParser(MarkupSettings settings)
    {
        _settings = settings;
        _stringBuilder = new StringBuilder();
    }
    
    public void Parse(string template, FileGraph fileGraph)
    {
        var lineCount = 0;
        var activeFileNode = fileGraph.Root;
        
        using (var reader = new StringReader(template))
        {
            ++lineCount;
            string? line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                Regex regex = new Regex(MarkupPatterns.TemplateParserPattern);
                var match = regex.Match(line);
                if (match.Success)
                {
                    activeFileNode?.UpdateNode(match, _settings, lineCount);
                    activeFileNode?.AddLines(_stringBuilder);
                    activeFileNode = activeFileNode?.Next();
                }
                else
                {
                    _stringBuilder.AppendLine(line);
                }
            }
        }
    }
}