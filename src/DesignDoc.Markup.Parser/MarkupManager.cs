using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class MarkupManager
{
    private DocFilesValidator _dfValidator;
    private DocFilesParser _dfParser;
    private TemplateValidator _tmpValidator;
    private TemplateParser _tmpParser;
    private string _template;
    private FileGraph _docFiles;
    
    public MarkupManager(string template, FileGraph docFiles, MarkupSettings settings)
    {
        _template = template;
        _docFiles = docFiles;
        _dfValidator = new DocFilesValidator();
        _dfParser = new DocFilesParser();
        _tmpValidator = new TemplateValidator();
        _tmpParser = new TemplateParser(settings);
    }

    public string GenerateDocument()
    {
        // Validate
        if (!_dfValidator.Validate(_docFiles)) throw new Exception("Doc Files failed validation.");
        if (!_tmpValidator.Validate(_template)) throw new Exception("Template failed validation.");
        
        // Parse
        _tmpParser.Parse(_template, _docFiles);

        // Map Graphs
        
        // Write Detail Document
        
        return "This is not implemented";
    }
}