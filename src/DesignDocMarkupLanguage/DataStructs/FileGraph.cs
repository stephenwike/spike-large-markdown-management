﻿namespace DesignDocMarkupLanguage.DataStructs;

public class FileGraph
{
    public FileGraph(DirectoryInfo rootDir)
    {
        Root = new FileGraphNode(null, rootDir);
    }
    
    public FileGraphNode Root { get; set; }
}