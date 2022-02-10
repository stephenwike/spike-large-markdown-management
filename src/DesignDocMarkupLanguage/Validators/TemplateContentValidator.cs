using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Validators;

public class TemplateContentValidator
{
    public void ValidateAndUpdate(TemplateQueue template, FileGraph files)
    {
        var steps = template.Steps;
        var contextNode = files.Root;
        var prevPath = Settings.RootDir;
        foreach (var step in steps)
        {
            if (step.Action == TemplateAction.FileRef)
            {
                step.Path = step.Label;
                if (!File.Exists(Path.Combine(Settings.RootDir.LocalPath, step.Path)))
                    throw new Exception($"File {step.Path} not found in path {Settings.RootDir.LocalPath}");
                continue;
            }
            contextNode = contextNode.Find(step.Label, step.Depth);
            if (contextNode == null)
                throw new Exception($"Could not find file or directory {step.Label} as specified in template at line {step.Line}.");
            if (contextNode.Directory != null) step.Path = contextNode.Directory.FullName;
            if (contextNode.File != null)
            {
                step.Path = contextNode.File.FullName;
                step.HasContent = true;
            }
            step.Summary = contextNode.Value.Summary;
        }
    }
}