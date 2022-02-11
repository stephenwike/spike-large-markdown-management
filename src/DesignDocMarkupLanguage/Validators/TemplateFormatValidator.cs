using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Helpers;

namespace DesignDocMarkupLanguage.Validators;

public class TemplateFormatValidator
{
    public TemplateQueue Validate(string[] template)
    {
        var queue = new TemplateQueue();
        var regex = new Regex(Patterns.TemplatePattern);
        for(var index = 0; index < template.Length; ++index)
        {
            var match = regex.Match(template[index]);
            if (!match.Success) continue;
            queue.AddStep(RegexMapHelper.MapTemplateStep(match, index));
            if (!IsOpeningTag(match.Groups["Open"].Value))
                throw new Exception($"Template Error (#{index}). Expected opening tag but got {match.Groups["Open"].Value}.");
            if (!IsClosingTag(match.Groups["Close"].Value))
                throw new Exception($"Template Error (#{index}). Expected closing tag but got {match.Groups["Close"].Value}.");
            if (!IsTagMatched(match.Groups["Open"].Value, match.Groups["Close"].Value))
                throw new Exception($"Template Error (#{index}). Opening tag {match.Groups["Open"].Value} has to be paired with correct closing tag, but got {match.Groups["Close"].Value}.");
        }

        return queue;
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