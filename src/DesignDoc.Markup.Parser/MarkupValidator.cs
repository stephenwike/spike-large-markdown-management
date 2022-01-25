using System.Text.RegularExpressions;

namespace DesignDoc.Markup.Parser;

public class MarkupValidator
{
    public bool Validate(string template)
    {
        var pattern = @"\{:|:\}";
        var regex = new Regex(pattern);
        var matches = regex.Matches(template);
        
        var stack = new Stack<string>();
        foreach (Match match in matches) 
        {
            Console.WriteLine(match.Value);
            if (!stack.Any() || string.IsNullOrWhiteSpace(stack.Peek()) || !IsTagClosed(match.Value, stack.Peek()))
            {
                stack.Push(match.Value);
            }
            else
            {
                stack.Pop();
            }
        }
        
        return !stack.Any();
    }

    private static bool IsTagClosed(string source, string target)
    {
        switch(source)
        {
            case ReservedMarkup.RegularOpen:
            {
                return (target == ReservedMarkup.RegularClosed);
            }
            case ReservedMarkup.RegularClosed:
            {
                return (target == ReservedMarkup.RegularOpen);
            }
            case ReservedMarkup.BlockOpen:
            {
                return (target == ReservedMarkup.BlockClosed);
            }
            case ReservedMarkup.BlockClosed:
            {
                return (target == ReservedMarkup.BlockOpen);
            }
            default:
            {
                return false;
            }
        }
    }
}