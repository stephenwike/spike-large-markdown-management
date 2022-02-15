using System.Text;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Models;

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

    /// <summary>
    /// Given a template broken by newline into a string array,
    /// and a template queue containing the queue of template steps,
    /// will add content related to each step into the template.
    /// </summary>
    /// <param name="template">The template as a string array.</param>
    /// <param name="templateQueue">Data structure containing template steps.</param>
    /// <returns>Template array with content inserted based on template steps.</returns>
    public string[] Parse(string[] template, TemplateQueue templateQueue)
    {
        var queue = templateQueue.Queue;
        if (!queue.Any()) return template;
            
        var nextStep = queue.Dequeue();
        var document = new List<string>();
        for (var index = 0; index < template.Length; ++index)
        {
            if (nextStep.Index == index)
            {
                while (nextStep.Index == index)
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
            content.AddRange(nextStep.AllLines);
            content.Add(string.Empty);
        }

        return content;
    }
    
    private List<string> CollapseStep(TemplateStep nextStep)
    {
        var content = new List<string>();
        if (nextStep.HasContent)
        {
            content.Add($"<details id=\"{nextStep.Id}\">");
            content.Add($"<summary>{nextStep.Summary}</summary>");
            content.Add(string.Empty);
            content.AddRange(nextStep.AllLines);
            content.Add(string.Empty);
            content.Add(@"</details>");
            content.Add(string.Empty);
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