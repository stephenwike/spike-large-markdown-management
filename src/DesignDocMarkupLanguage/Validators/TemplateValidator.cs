using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.Validators;

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
            if (!IsOpeningTag(matches[0].Value))
                throw new Exception($"Expected opening tag but got {matches[0].Value}");
            if (!IsClosingTag(matches[1].Value))
                throw new Exception($"Expected closing tag but got {matches[1].Value}");
            if (!IsTagMatched(matches[0].Value, matches[1].Value))
                throw new Exception($"Opening tag {matches[0].Value} has to be paired with correct closing tag, but got {matches[1].Value}");
        }
    }

    private static bool IsOpeningTag(string source)
    {
        return (source == ReservedMarkup.RegularOpen ||
                source == ReservedMarkup.CollapseOpen);
    }
    
    private static bool IsClosingTag(string source)
    {
        return (source == ReservedMarkup.RegularClosed ||
                source == ReservedMarkup.CollapseClosed);
    }
    
    private static bool IsTagMatched(string source, string target)
    {
        switch(source)
        {
            case ReservedMarkup.RegularOpen:
            {
                return (target == ReservedMarkup.RegularClosed);
            }
            case ReservedMarkup.CollapseOpen:
            {
                return (target == ReservedMarkup.CollapseClosed);
            }
            default:
            {
                return false;
            }
        }
    }
}