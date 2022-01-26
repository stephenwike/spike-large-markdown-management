// See https://aka.ms/new-console-template for more information

using DesignDoc.Markup.Parser;

// Resources
var templateFile = @"C:\spike\spike-large-markdown-management\docs\DDD-template\ddd-template.md";
var docFilesDir = @"C:\spike\spike-large-markdown-management\docs\DDD-template";
var outputDir = @"C:\spike\spike-large-markdown-management\docs\DDD.md";

// Probably implemented with flags.
var settings = new MarkupSettings();

new MarkupConverter(templateFile, docFilesDir, outputDir, settings).Build();
