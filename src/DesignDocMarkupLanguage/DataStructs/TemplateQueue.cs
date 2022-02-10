using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.Models;

namespace DesignDocMarkupLanguage.DataStructs;

public class TemplateQueue
{
    private Queue<TemplateStep>? _queue;
    private readonly List<TemplateStep> _steps;

    public TemplateQueue()
    {
        _steps = new List<TemplateStep>();
    }

    public List<TemplateStep> Steps => _steps;

    public Queue<TemplateStep> Queue
    {
        get
        {
            if (_queue != null && _queue.Any()) return _queue;
            return CompileActions();
        }
    }
    
    public void AddStep(TemplateStep step)
    {
        _steps.Add(step);
    }
    
    private Queue<TemplateStep> CompileActions()
    {
        _queue = new Queue<TemplateStep>();
        TemplateStep prevStep = null;
        var nestStack = new Stack<NestCloseInfo>();
        foreach (var step in _steps)
        {
            // If the current step is a nested collapse, add a
            // NestOpen action before inserting the next action.
            if (prevStep != null && prevStep.Depth < step.Depth && prevStep.Action == TemplateAction.Collapse)
            {
                var newStep = new TemplateStep()
                {
                    Action = TemplateAction.NestOpen,
                    Depth = prevStep.Depth,
                    Line = prevStep.Line,
                    Summary = prevStep.Summary,
                    Id = prevStep.Id
                };
                _queue.Enqueue(newStep);
                
                nestStack.Push(new NestCloseInfo()
                {
                    NestedId = nestStack.Any() ? $"{nestStack.Peek().NestedId}-{newStep.Id}" : newStep.Id
                });
            }

            // If the current step has left the nested context, add a NestClose action
            // for each context it left before inserting the next action
            if (prevStep != null && prevStep.Depth > step.Depth && nestStack.Any())
            {
                for (var index = 0; index < prevStep.Depth - step.Depth; ++index)
                {
                    if (!nestStack.Any()) break;
                    
                    nestStack.Pop();
                    _queue.Enqueue(new TemplateStep()
                    {
                        Action = TemplateAction.NestClose,
                        Depth = step.Depth,
                        Id = step.Id,
                        Line = step.Line
                    });
                    
                }
            }

            if (nestStack.Any()) step.Id = $"{nestStack.Peek().NestedId}-{step.Id}";
            
            _queue.Enqueue(step);
            prevStep = step;
        }

        return _queue;
    }
}