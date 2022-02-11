using CommandLine;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.CLI;

public class Options
{
    [Option('t', "templatefile", 
        Required = true, 
        HelpText = "The file path and file name of the DDML template file.")]
    public string TemplateFile { get; set; }
    
    [Option('d', "docsfolder", 
        Required = true, 
        HelpText = "The root directory of the documents to be nested into the template.")]
    public string DocsFolder { get; set; }
    
    [Option('o', "output", 
        Required = true, 
        HelpText = "The file path and file name of the compiled design document.")]
    public string Output { get; set; }
    
    [Option('r', "rootdirectory", 
        Required = true, 
        HelpText = "The file path where the script is being run.")]
    public string RootDir { get; set; }
    
    [Option('i', "indenttype", 
        Required = false, 
        Default = IndentTypes.FourSpaces, 
        HelpText = "Set the indentation type, Must match 'tabs', 'threespaces', or 'fourspaces'.")]
    public IndentTypes IndentType { get; set; }
}