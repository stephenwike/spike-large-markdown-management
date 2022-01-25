using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class MarkupConverter
{
    private MarkupManager _manager;
    private string _outputDir;
    private MarkupSettings _settings;
    public MarkupConverter(string templateDir, string docFilesDir, string outputDir, MarkupSettings? settings = null)
    {
        _settings = settings ?? new MarkupSettings();
        
        var template = File.ReadAllText(templateDir);
        var docFilesGraph = GetDocumentStructure(docFilesDir);
        _outputDir = @"C:\spike\spike-large-markdown-management\docs\DDD.md";
        
        _manager = new MarkupManager(template, docFilesGraph, _settings);
    }

    private FileGraph GetDocumentStructure(string docFilesDir)
    {
        var di = new DirectoryInfo(docFilesDir);
        var graph = new FileGraph(di);

        graph.Root.ParseNodesRecursive();
        return graph;
    }
    
    public async Task Build()
    {
        var document = _manager.GenerateDocument();
        await File.WriteAllTextAsync(_outputDir, document).ConfigureAwait(false);
    }
}