using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Helpers;
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
        if (Settings.TemplateUri?.LocalPath == null) throw new SystemException("Template Uri should not be null, failed to catch error in validator.");
        var template = ContentHelper.GetContent(Settings.TemplateUri.LocalPath);
        if (!template.Any()) throw new Exception($"Provided template file is empty at {Settings.TemplateUri.LocalPath}.");
        
        // Validate template and get template queue.
        var templateQueue = _tmpFormatValidator.Validate(template);
        
        // Create DocFiles graph.
        if (Settings.DocFilesURi == null) throw new SystemException("DocFiles Uri should not be null, failed to catch error in validator.");
        var docFiles = _dfParser.Parse(Settings.DocFilesURi);
        if (docFiles?.Root?.Children == null) throw new Exception($"Provided documents folder is empty at {Settings.DocFilesURi.LocalPath}.");

        // Validate template and update with DocFiles graph
        _tmpContentValidator.ValidateAndUpdate(templateQueue, docFiles);

        // Build the document
        var documentStrings = _docBuilder.Parse(template, templateQueue);
        var document = _docBuilder.Build(documentStrings);
        
        // Write document
        if (Settings.OutputUri?.LocalPath == null) throw new SystemException("Output Uri should not be null, failed to catch error in validator.");
        File.WriteAllText(Settings.OutputUri.LocalPath, document);
    }
}