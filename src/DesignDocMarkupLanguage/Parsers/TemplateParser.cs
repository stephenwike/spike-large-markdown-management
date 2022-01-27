using System.Text;
using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Extensions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Parsers;

public class TemplateParser
{
    private readonly StringBuilder _stringBuilder;

    public TemplateParser()
    {
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
                    activeFileNode?.UpdateNode(match, lineCount);
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