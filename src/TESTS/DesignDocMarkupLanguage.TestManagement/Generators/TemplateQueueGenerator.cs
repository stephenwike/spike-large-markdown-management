using System.Linq;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Models;

namespace DesignDocMarkupLanguage.TestManagement.Generators;

public class TemplateQueueGenerator
{
    private TemplateQueue _queue;
    
    public TemplateQueueGenerator GenerateQueue()
    {
        _queue = new TemplateQueue();
        return this;
    }

    public TemplateQueueGenerator AddStep(int depth, TemplateAction action, string label, int index, string[]? content = null)
    {
        var step = new TemplateStep()
        {
            Depth = depth,
            Action = action,
            Id = "TestId",
            Summary = label,
            Label = label,
            Index = index,
            Line = index + 1,
        };

        if (content != null && content.Any())
        {
            step.HasContent = true;
            step.AllLines = content;
        }
        
        _queue.AddStep(step);
        return this;
    }

    public TemplateQueue Build()
    {
        return _queue;
    }
}