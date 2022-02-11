#!/usr/bin/env pwsh

$toolName = "DesignDocMarkupLanguage"

dotnet tool install --global $toolName

$rootDir = $(Get-Location)

ddml -t .\docs\ddml-template.md -d .\docs\ -o .\README.md -r $rootDir
if (! ($?)) {
    throw "failed to compile document.";
}