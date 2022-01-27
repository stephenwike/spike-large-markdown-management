using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions;

namespace DesignDocMarkupLanguage.TestManagement;

public class TestFilesFixture: IDisposable
{
    private Uri BaseDir;
    public Dictionary<string, Uri> Directories { get; set; }
    public Dictionary<string, Uri> Files { get; set; }

    public static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => callerFilePath ?? "";

    public string? GetBaseDirectory(int levelsUp = 0)
    {
        var basedir = GetSourceFilePathName();

        for (int i = 0; i < levelsUp; ++i)
        {
            basedir = Directory.GetParent(basedir)?.FullName;
        }

        return basedir;
    }
    
    public TestFilesFixture()
    {
        var basedir = GetBaseDirectory();
        var mgmtDir = Directory.GetParent(basedir);
        BaseDir = new Uri(Path.Combine(mgmtDir.FullName, "TestFiles"));
        Directories = new Dictionary<string, Uri>();
        Files = new Dictionary<string, Uri>();
    }

    public void AddClassName(string classname)
    {
        BaseDir = new Uri(BaseDir, classname);
    }
    
    public void CreateDirectory(string path)
    {
        var uri = new Uri(BaseDir, path);
        Directory.CreateDirectory(uri.LocalPath);
        Directories.ContainsKey(path).Should().BeFalse();
        Directories.Add(path, uri);
    }
    
    public void CreateFile(string path)
    { 
        var uri = new Uri(BaseDir, path);
        //File.Create(uri.LocalPath); //TODO: Come back to this. Not working. UnauthorizedAccess Exception.
        Files.ContainsKey(path).Should().BeFalse();
        Files.Add(path, uri);
    }

    public void Dispose()
    {
        Files.ToList().ForEach(x => 
            File.Delete(x.Value.LocalPath));
        Directories.ToList().ForEach(x => 
            Directory.Delete(x.Value.LocalPath, true));
    }
}