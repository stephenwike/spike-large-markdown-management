using System.Text.RegularExpressions;

namespace DesignDoc.Markup.Parser;

public class TemplateValidator
{
    public void Validate(string template)
    {
        var regex = new Regex(Patterns.ReservedMarkup);

        var lines = template.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        foreach(var line in lines)
        {
            var matches = regex.Matches(line);
            if (matches.Count == 0) continue;
            if (matches.Count != 2)
                throw new Exception($"Expected two element tags per line and got {matches.Count}");
            if (!IsTagClosed(matches[0].Value, matches[1].Value))
                throw new Exception($"Opening tag {matches[0].Value} has to be paired with correct closing tag, but got {matches[1].Value}");
        }
    }

    private static bool IsTagClosed(string source, string target)
    {
        switch(source)
        {
            case ReservedMarkup.RegularOpen:
            {
                return (target == ReservedMarkup.RegularClosed);
            }
            case ReservedMarkup.BlockOpen:
            {
                return (target == ReservedMarkup.BlockClosed);
            }
            default:
            {
                return false;
            }
        }
    }
}