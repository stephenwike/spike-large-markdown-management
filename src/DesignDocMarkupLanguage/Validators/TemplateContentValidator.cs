using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Helpers;

namespace DesignDocMarkupLanguage.Validators;

public class TemplateContentValidator
{
    public void ValidateAndUpdate(TemplateQueue template, FileGraph files)
    {
        var steps = template.Steps;
        var contextNode = files.Root;
        foreach (var step in steps)
        {
            contextNode = contextNode.Find(step.Label, step.Depth);
            if (contextNode == null)
                throw new Exception($"Could not find file or directory {step.Label} as specified in template at line {step.Line}.");
            if (contextNode.File != null)
            {
                step.HasContent = true;
                step.AllLines = ContentHelper.GetContent(contextNode.File.FullName);
            }
            step.Summary = contextNode.Value.Summary;
        }
    }
}