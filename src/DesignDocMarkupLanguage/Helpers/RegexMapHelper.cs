using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Models;

namespace DesignDocMarkupLanguage.Helpers;

public static class RegexMapHelper
{
    public static TemplateStep MapTemplateStep(Match match, int index)
    {
        var step = new TemplateStep()
        {
            Depth = TemplateHelper.GetDepth(match.Groups["Tabs"].Value),
            Action = TemplateHelper.GetStepType(match.Groups["Open"].Value),
            Id = TemplateHelper.GetId(match.Groups["Label"].Value),
            Label = match.Groups["Label"].Value,
            Index = index,
            Line = index + 1,
        };
        return step;
    }
}