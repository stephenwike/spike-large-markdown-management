using System.Text;
using System.Text.RegularExpressions;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Extensions;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Helpers;

namespace DesignDocMarkupLanguage.Parsers;

public class DocumentBuilder
{
    public string Build(string[] template)
    {
        var stringBuilder = new StringBuilder();

        var prevLineIsEmpty = false;
        foreach (var line in template)
        {
            if (prevLineIsEmpty && string.IsNullOrWhiteSpace(line)) continue;
            prevLineIsEmpty = string.IsNullOrWhiteSpace(line);

            stringBuilder.AppendLine(line);
        }
        
        return stringBuilder.ToString();
    }

    public string[] Parse(string[] template, TemplateQueue templateQueue)
    {
        var queue = templateQueue.Queue;
        var nextStep = queue.Dequeue();
        var document = new List<string>();
        for (var index = 0; index < template.Length; ++index)
        {
            if (nextStep.Line == index)
            {
                while (nextStep.Line == index)
                {
                    var content = StepContent(nextStep);
                    document.AddRange(content);

                    if (!queue.Any()) break;
                    nextStep = queue.Dequeue();
                }
            }
            else
            {
                document.Add(template[index]);
            }
        }

        return document.ToArray();
    }

    private List<string> StepContent(TemplateStep nextStep)
    {
        switch (nextStep.Action)
        {
            case TemplateAction.Regular: return RegularStep(nextStep);
            case TemplateAction.Collapse: return CollapseStep(nextStep);
            case TemplateAction.FileRef: return FileRefStep(nextStep);
            case TemplateAction.NestOpen: return NestOpenStep(nextStep);
            case TemplateAction.NestClose: return NestCloseStep(nextStep);
            default:
                throw new Exception(
                    $"System exception. Unexpected TemplateAction {nextStep.Action} received in method DocumentBuilder.SetContent.");
        }
    }

    private List<string> RegularStep(TemplateStep nextStep)
    {
        var content = new List<string>();
        
        var hashes = new string(Enumerable.Repeat('#', nextStep.Depth).ToArray());
        content.Add($"{hashes} {nextStep.Summary}");
        content.Add(string.Empty);

        if (nextStep.HasContent)
        {
            content.AddRange(File.ReadAllLines(nextStep.Path));
            content.Add(string.Empty);
        }

        return content;
    }
    
    private List<string> CollapseStep(TemplateStep nextStep)
    {
        var content = new List<string>();
        
        var filePath = Path.GetFullPath(Path.Combine(Settings.RootDir.LocalPath, nextStep.Path));
        if (nextStep.HasContent)
        {
            content.Add($"<details id=\"{nextStep.Id}\">");
            content.Add($"<summary>{nextStep.Summary}</summary>");
            content.Add(string.Empty);
            content.AddRange(File.ReadAllLines(filePath));
            content.Add(string.Empty);
            content.Add(@"</details>");
            content.Add(string.Empty);
        }

        return content;
    }
    
    private List<string> FileRefStep(TemplateStep nextStep)
    {
        if (nextStep.FileRef == null) throw new SystemException();
        
        var content = new List<string>();
        
        var filePath = Path.GetFullPath(Path.Combine(Settings.RootDir.LocalPath, nextStep.Path));
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath).Skip(nextStep.FileRef.Start);
            if (nextStep.FileRef.Length >= 0) { lines = lines.Take(nextStep.FileRef.Length); }

            content.Add(@"```csharp"); // TODO:  Should be dynamic based on extension.
            content.AddRange(lines);
            content.Add(@"```");
        }
        
        return content;
    }
    
    private List<string> NestOpenStep(TemplateStep nextStep)
    {
        var content = new List<string>();
        content.Add($"<details id=\"{nextStep.Id}\">");
        content.Add($"<summary>{nextStep.Summary}</summary>");
        content.Add("<blockquote>");
        content.Add(string.Empty);
        return content;
    }
    
    private List<string> NestCloseStep(TemplateStep nextStep)
    {
        var content = new List<string>();
        content.Add("</blockquote>");
        content.Add(@"</details>");
        content.Add(string.Empty);
        return content;
    }
}