using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.Validators;

namespace DesignDocMarkupLanguage.Managers;

public class MarkupManager
{
    private readonly DocFilesValidator _dfValidator;
    private readonly DocFilesParser _dfParser;
    private readonly TemplateValidator _tmpValidator;
    private readonly TemplateParser _tmpParser;
    private readonly Uri _templateFile;
    private readonly Uri _docFilesDir;
    private readonly Uri _output; // TODO: Should this be a setting?
    
    public MarkupManager(Uri templateFile, Uri docFiles, Uri output)
    {
        _templateFile = templateFile;
        _docFilesDir = docFiles;
        _output = output;
        _dfValidator = new DocFilesValidator();
        _dfParser = new DocFilesParser();
        _tmpValidator = new TemplateValidator();
        _tmpParser = new TemplateParser();
    }

    public void GenerateDocument()
    {
        // Validate Template
        var template = File.ReadAllText(_templateFile.LocalPath);
        _tmpValidator.Validate(template);
        
        // Create DocFiles Graph
        var docFiles = _dfParser.Parse(_docFilesDir);
        
        // Validate Doc Files
        _dfValidator.Validate(docFiles);
        
        // Parse Template with DocFiles Graph
        var document = _tmpParser.Parse(template, docFiles);
        
        // Write Document
        File.WriteAllText(_output.LocalPath, document);
    }
}