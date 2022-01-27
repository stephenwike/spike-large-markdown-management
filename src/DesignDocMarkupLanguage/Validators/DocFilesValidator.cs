using DesignDocMarkupLanguage.DataStructs;

namespace DesignDocMarkupLanguage.Validators;

public class DocFilesValidator
{
    public void Validate(FileGraph docFiles)
    {
        if (docFiles?.Root == null) 
            throw new NullReferenceException(nameof(FileGraph));
        if (docFiles.Root.Children == null) 
            throw new NullReferenceException(nameof(FileGraph));

        ValidateSequenceRecursive(docFiles.Root.Children);
    }

    private void ValidateSequenceRecursive(List<FileGraphNode>? children)
    {
        if (children == null) return;
        for (int i = 0; i < children.Count; ++ i)
        {
            if (children[i].Value.FileNumber != i + 1)
                throw new Exception($"File {children[i].Value.FullName} FileNumber was expected to be {i + 1} but got {children[i].Value.FileNumber}.");

            if (children[i].Children != null)
            {
                ValidateSequenceRecursive(children[i].Children);
            }
        };
    }
}