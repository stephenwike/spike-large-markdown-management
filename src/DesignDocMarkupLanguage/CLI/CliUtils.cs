using CommandLine;
using DesignDocMarkupLanguage.Validators;

namespace DesignDocMarkupLanguage.CLI;

public class CliUtils
{
    public void RunOptions(Options opts)
    {
        new OptionsValidator().Validate(opts);
        Settings.IndentType = opts.IndentType;
    }

    public void HandleParseError(IEnumerable<Error> errs)
    {
        
        Console.WriteLine("{DesignDocMarkupLanguage.CLI} HandleParseError reached but not implemented.");
        
    }
}