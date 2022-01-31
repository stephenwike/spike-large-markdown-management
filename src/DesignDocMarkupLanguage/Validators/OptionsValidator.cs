using DesignDocMarkupLanguage.CLI;

namespace DesignDocMarkupLanguage.Validators;

public class OptionsValidator
{
    public void Validate(Options opts)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        // Does the template file exist?
        //if (!File.Exists(opts.TemplateFile.LocalPath))
        //    throw new NullReferenceException($"File does not exist: {opts.TemplateFile}");
        
        // Does the root doc files directory exist?
        //if (!Directory.Exists(opts.DocsFolder.LocalPath))
        //    throw new NullReferenceException($"Directory does not exist: {opts.DocsFolder}");
    }
}