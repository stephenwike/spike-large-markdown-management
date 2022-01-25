using System.Text.RegularExpressions;
using DesignDoc.Markup.Parser;

public class TemplateParser
{
    public TemplateGraph Parse(string template)
    {
        var lineCount = 0;
        using (var reader = new StringReader(template))
        {
            ++lineCount;
            string? line = string.Empty;
            while((line = reader.ReadLine()) != null)
            {
                Regex regex = new Regex(MarkupPatterns.TemplateParserPattern);
                var matches = regex.Matches(line);
                
                // Matches should only return one header per line.
                if (matches.Count > 1)
                {
                    var message = string.Format(
                        "Bad syntax '{match}' found in template ({line},{index}).  Tags must be limited to one per line.",
                        matches[1].Value, lineCount, matches[1].Index
                    );
                    throw new Exception(message);
                }

                // If there is a match, build node.
                var match = matches.FirstOrDefault();
                if (match != null)
                {
                    var header = match.Groups["Header"] ?? throw new Exception("Null Header Group");
                    var page = match.Groups["Page"] ?? throw new Exception("Null Page Group");
                    var tabs = match.Groups["Tabs"]?.Value?.Length ?? throw new Exception("Null Tabs Group");
                    
                    
                }
            }
        }

        return new TemplateGraph();
    }
}