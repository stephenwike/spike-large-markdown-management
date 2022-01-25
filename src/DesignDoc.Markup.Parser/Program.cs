// See https://aka.ms/new-console-template for more information

using DesignDoc.Markup.Parser;

Console.WriteLine("Hello, World!");

// Resources
var templateDir = @"C:\spike\spike-large-markdown-management\docs\DDD-template\ddd-template";
var docFilesDir = @"C:\spike\spike-large-markdown-management\docs\DDD-template";
var outputDir = @"C:\spike\spike-large-markdown-management\docs\DDD.md";

// Probably implemented with flags.
var settings = new MarkupSettings();

var converter = new MarkupConverter(templateDir, docFilesDir, outputDir, settings).Build();
