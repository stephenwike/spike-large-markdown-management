using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
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
            Line = index
        };
        if (step.Action == TemplateAction.FileRef)
        {
            var lineOptions = match.Groups["Lines"].Value;
            if (string.IsNullOrWhiteSpace(lineOptions))
                throw new Exception($"Line options delimiter ':' found but no values given on element {step.Label} on line {step.Line}");
            
            var options = lineOptions.Split(',');
            var start = int.Parse(options[0]);
            step.FileRef = new FileReference()
            {
                Start = start - 1, // Inclusive
                Length = (options.Length == 2) ? int.Parse(options[1]) - start : -1
            };
        }
        
        return step;
    }
}