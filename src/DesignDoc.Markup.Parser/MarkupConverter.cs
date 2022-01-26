using DesignDoc.Markup.Parser.DataStructs;

namespace DesignDoc.Markup.Parser;

public class MarkupConverter
{
    private MarkupManager _manager;
    private string _outputFile;
    private MarkupSettings _settings;
    public MarkupConverter(string templateFile, string docFilesDir, string outputFile, MarkupSettings? settings = null)
    {
        _settings = settings ?? new MarkupSettings();
        
        var template = File.ReadAllText(templateFile);
        var docFilesGraph = GetDocumentStructure(docFilesDir); // TODO: Move this logic into a filesGraph parser.
        _outputFile = outputFile;
        
        _manager = new MarkupManager(template, docFilesGraph, _settings);
    }

    private FileGraph GetDocumentStructure(string docFilesDir)
    {
        var di = new DirectoryInfo(docFilesDir);
        var graph = new FileGraph(di);

        graph.Root.ParseNodesRecursive();
        return graph;
    }
    
    public void Build()
    {
        var document = _manager.GenerateDocument();
        File.WriteAllText(_outputFile, document);
    }
}