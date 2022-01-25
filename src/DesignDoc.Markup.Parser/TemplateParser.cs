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
            while(line = reader.ReadLine != null)
            {
                Regex regex = new Regex(MarkupPatterns.TemplateParserPattern);
                var matches = new regex.Matches(line);
                
                // Matches should only return one tag per line.
                if (matches > 1)
                {
                    var message = string.Format(
                        "Bad syntax '{match}' found in template ({line},{index}).  Tags must be limited to one per line.",
                        matches[1].Value, lineCount, matches[1].Index
                    );
                    throw new Exception(message);
                }
            }
        }

        return new TemplateGraph();
    }
}