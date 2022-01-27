using System;
using System.IO;
using DesignDocMarkupLanguage.DataStructs;
using DesignDocMarkupLanguage.Parsers;

namespace DesignDocMarkupLanguage.TestManagement.Generators;

public class FileGraphGenerator
{
    public TestFilesFixture _fixture = new TestFilesFixture();
    public FileGraph GenerateFileGraph(string rootDir)
    {
        var path = _fixture.GetBaseDirectory(2);
        path = Path.Combine(path, "TestFiles", rootDir);
        var graph = new DocFilesParser().Parse(new Uri(path));
        return graph;
    }
}