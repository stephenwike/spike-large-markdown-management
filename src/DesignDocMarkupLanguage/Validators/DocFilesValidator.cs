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
    }
}