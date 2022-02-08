using CommandLine;
using DesignDocMarkupLanguage.CLI;
using DesignDocMarkupLanguage.Managers;

// Build CLI
var cliUtils = new CliUtils();
var opts = Parser.Default.ParseArguments<Options>(args)
    .WithParsed(cliUtils.RunOptions)
    .WithNotParsed(cliUtils.HandleParseError).Value;

// Generate Document
var manager = new MarkupManager();
manager.GenerateDocument();
