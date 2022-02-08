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
    public string Build(string[] template, FileGraph fileGraph)
    {
        StringBuilder stringBuilder = new StringBuilder();
        var contextNode = fileGraph.Root;
        for (var index = 0; index < template.Length; ++index)
        {
            var line = template[index];
            Regex regex = new Regex(Patterns.TemplatePattern);
            var match = regex.Match(line);
            if (match.Success)
            {
                if (match.Groups["Open"].Value == ReservedMarkup.FileOpen)
                {
                    // Get File Contents
                    var fileMatch = new Regex(Patterns.FileTagPattern).Match(match.Groups["Label"].Value);
                    var start = 0;
                    var length = -1;
                    var lineOptions = fileMatch.Groups["Lines"].Value;
                    if (!string.IsNullOrWhiteSpace(lineOptions!))
                    {
                        var options = lineOptions.Split(',');
                        start = int.Parse(options[0]) - 1; // Inclusive
                        if (options.Length == 2)
                        {
                            length = int.Parse(options[1]) - start;
                        }
                    }

                    var filePath = Path.GetFullPath(Path.Combine(Settings.RootDir.LocalPath, fileMatch.Groups["FilePath"].Value));
                    if (File.Exists(filePath))
                    {
                        var lines = File.ReadAllLines(filePath).Skip(start);
                        if (length >= 0) { lines = lines.Take(length); }

                        stringBuilder.AppendLine(@"```csharp");
                        lines.ToList().ForEach(x => stringBuilder.AppendLine(x));
                        stringBuilder.AppendLine(@"```");
                    }
                }
                else
                {
                    var depth = TemplateHelper.GetDepth(match.Groups["Tabs"].Value);
                    var value = match.Groups["Label"].Value;
                    contextNode = contextNode.GetContext(value, depth);
                    if (contextNode == null)
                    {
                        throw new Exception($"Template Helper Error: Label {value} was not found at depth {depth}.");
                    }
                    stringBuilder.AddLines(contextNode);
                }
            }
            else
            {
                stringBuilder.AddLine(line);
            }
        }

        return stringBuilder.ToString();
    }

    public string[] Enrich(string[] template, FileGraph fileGraph)
    {
        var contextNode = fileGraph.Root;
        var closingNested = false;
        FileGraphNode? nodeNested = null;
        List<string> outLines = new List<string>();
        for (var index = 0; index < template.Length; ++index)
        {
            var line = template[index];
            var match = new Regex(Patterns.TemplatePattern).Match(line);
            if (match.Success && match.Groups["Open"].Value != ReservedMarkup.FileOpen)
            {
                var depth = TemplateHelper.GetDepth(match.Groups["Tabs"].Value);
                contextNode = contextNode.GetContext(match.Groups["Label"].Value, depth);
                if (contextNode == null) 
                    throw new IndexOutOfRangeException("Found tag that exceeded the last file/folder in the file docs directory.");
                
                // Close any currently running nested tags if depth is returned to starting node.
                if (closingNested && nodeNested?.Depth() == contextNode?.Depth())
                {
                    CloseNested(outLines);
                    closingNested = false;
                }

                if (contextNode != null && contextNode.Value.IsNesting)
                {
                    var id = TemplateHelper.GetNestedId(contextNode);
                    OpenNested(outLines, id, contextNode.Value.Summary ?? "", line);
                    closingNested = true;
                    nodeNested = contextNode;
                }
                else if (contextNode != null && contextNode.Value.IsCollapsed)
                {
                    var id = TemplateHelper.GetId(contextNode);
                    Collapse(outLines, id, contextNode.Value.Summary ?? "", line);
                }
                else
                {
                    outLines.Add(line);
                }
            }
            else if (closingNested && !string.IsNullOrWhiteSpace(line))
            {
                CloseNested(outLines);
                closingNested = false;
                outLines.Add(line);
            }
            else
            {
                outLines.Add(line);
            }
        }

        if (closingNested)
        {
            CloseNested(outLines);
            closingNested = false;
        }
        
        return outLines.ToArray();
    }

    private void Collapse(List<string> outLines, string id, string summary, string line)
    {
        outLines.Add($"<details id=\"{id}\">");
        outLines.Add($"<summary>{summary}</summary>");
        outLines.Add(Environment.NewLine);
        outLines.Add(line);
        outLines.Add(Environment.NewLine);
        outLines.Add(@"</details>");
        outLines.Add(Environment.NewLine);
    }

    private void OpenNested(List<string> outLines, string id, string summary, string line)
    {
        outLines.Add($"<details id=\"{id}\">");
        outLines.Add($"<summary>{summary}</summary>");
        outLines.Add("<blockquote>");
        outLines.Add(Environment.NewLine);
        outLines.Add(line);
        outLines.Add(Environment.NewLine);
    }

    private void CloseNested(List<string> outLines)
    {
        outLines.Add("</blockquote>");
        outLines.Add(@"</details>");
        outLines.Add(Environment.NewLine);
    }
}