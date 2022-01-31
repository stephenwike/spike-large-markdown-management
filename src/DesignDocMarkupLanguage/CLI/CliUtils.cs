using CommandLine;
using DesignDocMarkupLanguage.Validators;

namespace DesignDocMarkupLanguage.CLI;

public class CliUtils
{
    public void RunOptions(Options opts)
    {
        var curDir = Directory.GetCurrentDirectory();
        Console.WriteLine(curDir);
        var templatePath = Path.Combine(curDir, opts.TemplateFile);
        var docFilesPath = Path.Combine(curDir, opts.DocsFolder);
        var outputPath = Path.Combine(curDir, opts.Output);
        
        Settings.TemplateUri = new Uri(templatePath);
        Settings.DocFilesURi = new Uri(docFilesPath);
        Settings.OutputUri = new Uri(outputPath);

        Console.WriteLine();

        new OptionsValidator().Validate(opts);
        Settings.IndentType = opts.IndentType;
    }

    public void HandleParseError(IEnumerable<Error> errs)
    {
        
        Console.WriteLine("{DesignDocMarkupLanguage.CLI} HandleParseError reached but not implemented.");
        
    }
}