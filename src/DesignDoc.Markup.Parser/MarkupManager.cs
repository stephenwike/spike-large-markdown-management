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
        _tmpValidator.Validate(_template); // Throws exception of validation failed.
        
        // Parse
        return _tmpParser.Parse(_template, _docFiles);
    }
}