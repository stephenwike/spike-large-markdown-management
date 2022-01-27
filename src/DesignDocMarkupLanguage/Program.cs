using CommandLine;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Managers;

// Parse CLI
var cliUtils = new CliUtils();
var opts = Parser.Default.ParseArguments<Options>(args)
    .WithParsed(cliUtils.RunOptions)
    .WithNotParsed(cliUtils.HandleParseError).Value;

// TODO: Clean your mess!
// Resources
//var templateFile =  // @"C:\spike\spike-large-markdown-management\docs\DDD-template\ddd-template.md";
//var docFilesDir = @"C:\spike\spike-large-markdown-management\docs\DDD-template";
//var outputDir = @"C:\spike\spike-large-markdown-management\docs\DDD.md";

// Generate Document
var manager = new MarkupManager(opts.TemplateFile, opts.DocsFolder, opts.Output);
manager.GenerateDocument();
