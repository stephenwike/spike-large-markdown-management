using CommandLine;
using DesignDocMarkupLanguage.Constants;

namespace DesignDocMarkupLanguage.CLI;

public class Options
{
    [Option('t', "templatefile", 
        Required = true, 
        HelpText = "The file path and file name of the DDML template file.")]
    public Uri TemplateFile { get; set; }
    
    [Option('d', "docsfolder", 
        Required = true, 
        HelpText = "The root directory of the documents to be nested into the template.")]
    public Uri DocsFolder { get; set; }
    
    [Option('o', "output", 
        Required = true, 
        HelpText = "The file path and file name of the compiled design document.")]
    public Uri Output { get; set; }
    
    [Option('i', "indenttype", 
        Required = false, 
        Default = IndentTypes.FourSpaces, 
        HelpText = "Set the indentation type, Must match 'tabs', 'threespaces', or 'fourspaces'.")]
    public IndentTypes IndentType { get; set; }
}