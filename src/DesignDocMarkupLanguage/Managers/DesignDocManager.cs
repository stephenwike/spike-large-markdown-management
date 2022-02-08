using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.Validators;

namespace DesignDocMarkupLanguage.Managers;

public class MarkupManager
{
    private readonly DocFilesValidator _dfValidator;
    private readonly DocFilesParser _dfParser;
    private readonly TemplateValidator _tmpValidator;
    private readonly DocumentBuilder _tmpParser;

    public MarkupManager()
    {
        _dfValidator = new DocFilesValidator();
        _dfParser = new DocFilesParser();
        _tmpValidator = new TemplateValidator();
        _tmpParser = new DocumentBuilder();
    }

    public void GenerateDocument()
    {
        var template = File.ReadAllLines(Settings.TemplateUri.LocalPath);

        // Validate Template
        _tmpValidator.Validate(template);
        
        // Create DocFiles Graph
        var docFiles = _dfParser.Parse(Settings.DocFilesURi);
        
        // Validate Doc Files
        _dfValidator.Validate(docFiles);

        // Update Graph with template
        _dfParser.UpdateFileGraph(template, docFiles);

        // Build github tags into the template
        var enrichedTemplate = _tmpParser.Enrich(template, docFiles);
        
        // Build Template with DocFiles Graph
        var document = _tmpParser.Build(enrichedTemplate, docFiles);
        
        // Write Document
        File.WriteAllText(Settings.OutputUri.LocalPath, document);
    }
}