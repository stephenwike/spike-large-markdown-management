using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Constants;
using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Helpers;

public static class TemplateHelper
{
    public static int GetDepth(string tabs)
    {
        switch (Settings.IndentType)
        {
            case IndentTypes.Tabs:
                return tabs.Count(c => c == '\t') + 1;
            case IndentTypes.ThreeSpaces:
                return tabs.Count(Char.IsWhiteSpace) / 3 + 1;
            case IndentTypes.FourSpaces:
                return tabs.Count(Char.IsWhiteSpace) / 4 + 1;
            default:
                throw new Exception($"Settings misconfigured for IndentType. Type cannot be \"{Settings.IndentType}\"");
        }
    }

    public static string GetId(FileGraphNode? contextNode)
    {
        if (contextNode == null) return "id";

        return contextNode.Value.PageName.ToLower().Replace(' ', '-');
    }
    
    public static string GetId(string label)
    {
        if (string.IsNullOrWhiteSpace(label)) return "id";

        return label.ToLower().Replace(' ', '-');
    }
    
    public static string GetNestedId(FileGraphNode? contextNode)
    {
        if (contextNode?.Parent == null) return "id";

        var parentId = contextNode.Parent.Value.PageName.ToLower();
        var id = contextNode.Value.PageName.ToLower();

        return $"{parentId}-{id}".Replace(' ', '-');
    }

    public static TemplateAction GetStepType(string value)
    {
        switch (value)
        {
            case ReservedMarkup.CollapseOpen: return TemplateAction.Collapse;
            case ReservedMarkup.RegularOpen: return TemplateAction.Regular;
            default: throw new Exception($"TemplateHelper.GetStepType did not recognize opening tag {value}.");
        }
    }
}