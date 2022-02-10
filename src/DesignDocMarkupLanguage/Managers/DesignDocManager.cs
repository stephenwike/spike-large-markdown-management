using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Parsers;
using DesignDocMarkupLanguage.Validators;

namespace DesignDocMarkupLanguage.Managers;

public class MarkupManager
{
    private readonly DocFilesParser _dfParser;
    private readonly TemplateFormatValidator _tmpFormatValidator;
    private readonly TemplateContentValidator _tmpContentValidator;
    private readonly DocumentBuilder _docBuilder;

    public MarkupManager()
    {
        _dfParser = new DocFilesParser();
        _tmpFormatValidator = new TemplateFormatValidator();
        _tmpContentValidator = new TemplateContentValidator();
        _docBuilder = new DocumentBuilder();
    }

    public void GenerateDocument()
    {
        var template = File.ReadAllLines(Settings.TemplateUri.LocalPath);
        if (!template.Any()) throw new Exception($"Provided template file is empty at {Settings.TemplateUri.LocalPath}.");
        
        // Validate template and get template queue.
        var templateQueue = _tmpFormatValidator.Validate(template);
        
        // Create DocFiles graph.
        var docFiles = _dfParser.Parse(Settings.DocFilesURi);
        if (docFiles?.Root?.Children == null) throw new Exception($"Provided documents folder is empty at {Settings.DocFilesURi.LocalPath}.");

        // Validate template and update with DocFiles graph
        _tmpContentValidator.ValidateAndUpdate(templateQueue, docFiles);

        // Build the document
        var documentStrings = _docBuilder.Parse(template, templateQueue);
        var document = _docBuilder.Build(documentStrings);
        
        // Write document
        File.WriteAllText(Settings.OutputUri.LocalPath, document);
    }
}