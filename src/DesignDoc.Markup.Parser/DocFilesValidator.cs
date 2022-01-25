using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class DocFilesValidator
{
    public bool Validate(FileGraph docFiles)
    {
        if (docFiles?.Root == null) return false;
        if (docFiles.Root.Children == null) return true;
 
        return ValidateSequenceRecursive(docFiles.Root.Children);
    }

    private bool ValidateSequenceRecursive(List<FileGraphNode>? children)
    {
        if (children == null) return true;
        for (int i = 0; i < children.Count; ++ i)
        {
            if (children[i].Value.FileNumber !=  i)
            {
                return false;
            }

            if (children[i].Children != null)
            {
                return ValidateSequenceRecursive(children[i].Children);
            }
        };
        return true;
    }
}