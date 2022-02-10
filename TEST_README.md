# Design Document Markup Language (DDML)

This markup language is designed to templatize markdown files commonly used in repository documentation. This way, large markdown documents can be broken down into maintainable sized files and compiled into a final document. 

**This document was generated using the DDML tool.**

## 🗄 Project Organization

<details id="component-file-management">
<summary>Component File Management</summary>

Create a folder within your project to hold you component documents. Documents may be grouped into directories and subdirectories. It is recomendended to use directories as headings and keep content under the correct heading. Headings can be nested. If auto-headings is used, all headings after heading 6 will also be heading 6. Files will be appended in place as specified by the template. Files may be inserted in place, inside a collapsed GitHub tag or nested collapsed GitHub tag. Files not referenced in the template will be skipped.

</details>

<details id="template-file">
<summary>Template File</summary>

Create a markdown file within your project. This markdown file will define the structure of the document. Component documents are included into the fully compiled document using defined markup. The template file is a markdown file and may include all standard markdown and html.

</details>

<details id="template-rules">
<summary>Template Rules</summary>

* Each component document should be contained to a single line.
* The include markup must match the name of the document or directory, special characters excluded.
* Each include markup should be indented by how many parent directories it has.
* Indententions should be consistent and limited to tabs or spaces.
* Each include markup should be preceeded by it's parent or sibling include markups.
* Content may exists between include markup.
* Files may include numerals at the beginning of the document or directory but will be ignored by the compiler.

</details>

<details id="template-example">
<summary>Template Example</summary>

Here is an example of how the markup language is being used in this project.  The following snippet is the template file used to create this README.md.

```
::Design Document Markup Language (DDML)::

This markup language is designed to templatize markdown files commonly used in repository documentation. This way, large markdown documents can be broken down into maintainable sized files and compiled into a final document. 

**This document was generated using the DDML tool.**

    ::Project Organization::
        [:Component File Management:]
        [:Template File:]
        [:Template Rules:]
        [:Template Example:]

    ::Reserved Markup::

    ::Integrations

    ::Building and Running::
        [:Nuget:]
            [:Building:]
            [:Running:]
        [:GitHub:]
            [:Building:]
            [:Running:]

## Showing Example Code

You can include example code by providing the source filepath and optionally specifying which lines to display.

### Regex Patterns Used

Here are the regex patterns used for determining markup compatibility.

!:3,41:../src/DesignDocMarkupLanguage/Constants/Patterns.cs:!
```

</details>

## 🚧 Reserved Markup

### Reserved Markup

|Tag|Example|Type|Desciption|
|---|---|---|---|
|::|::MyHeading::|Directory|This is a standard folder include.  Creates a heading.|
|::|::MyContent::|File|This is a standard content include.  Creates a heading.|
|[:, :]|[:MyCollapsed:]|File|This is a collapsed content include.|
|!:, :!|!:./src/MyFile.ext:!|File|Get content from specified file.|
|!:n,m:, :!|!:3,15:./src/MyFile.ext:!|File|Get content from specified file.|
|->|::MyDir->MyFile::|File|Bypass parent directory.  Used to control order of content between multiple parent directories.|

## How To Use

<details id="linting">
<summary>Linting</summary>

Currently not implemented.

</details>

<details id="building-and-running">
<summary>🔨 Building and Running</summary>
<blockquote>

<details id="building-and-running-nuget">
<summary>Nuget</summary>
<blockquote>

<details id="building-and-running-building-and-running-nuget-building">
<summary>Building</summary>

TODO

</details>

<details id="building-and-running-building-and-running-nuget-running">
<summary>Running</summary>

TODO

</details>

</blockquote>
</details>

<details id="building-and-running-github">
<summary>GitHub</summary>
<blockquote>

<details id="building-and-running-building-and-running-github-building">
<summary>Building</summary>

#### Create NuGet Package

From the project root directory run:

```cmd
dotnet pack ./src/DesignDocMarkupLanguage/
```

> Successfully created package 'C:\spike\spike-large-markdown-management\src\DesignDocMarkupLanguage\nupkg\DesignDocMarkupLanguage.VERSION.nupkg'.

This will create the NuGet package into the ./nupkg folder.

#### Install

From the project root directory run:

```cmd
dotnet tool install --global --add-source src\DesignDocMarkupLanguage\nupkg DesignDocMarkupLanguage
```

> You can invoke the tool using the following command: ddml
> Tool 'designdocmarkuplanguage' (version 'VERSION') was successfully installed.

#### Uninstall

From the project root directory run:

```cmd
dotnet tool uninstall --global DesignDocMarkupLanguage
```

> Tool 'designdocmarkuplanguage' (version 'VERSION') was successfully uninstalled.

</details>

<details id="building-and-running-building-and-running-github-running">
<summary>Running</summary>

#### Running

From the project root run:

```cmd
$path = $(get-location)
ddml -t .\docs\ddml-template.md -d .\docs -o .\TEST_README.md -r $path
```

> You can invoke the tool using the following command: ddml
> Tool 'designdocmarkuplanguage' (version '1.0.0') was successfully installed.

</details>

</blockquote>
</details>

</blockquote>
</details>

<details id="pipeline-integration">
<summary>Pipeline Integration</summary>
<blockquote>

#### GitHub Actions

TODO

</blockquote>
</details>

## Showing Example Code

You can include example code by providing the source filepath and optionally specifying which lines to display.

### Regex Patterns Used

Here are the regex patterns used for determining markup compatibility.

> Although not implemented, in the future, embedded file references should be allowed to live inside the component file.

```csharp
public static class Patterns
{
    public static readonly string TemplatePattern = TemplatePatterns.Pattern;
    public static readonly string DocumentFilesPattern = DocFilesPatterns.Pattern;
}

public static class TemplatePatterns
{
    private static readonly string OpenMarkup = @"[\[!:]:";
    private static readonly string CloseMarkup = @":[\]!:]";
    private static readonly string OPEN = $"(?<Open>{OpenMarkup})";
    private static readonly string CLOSE = $"(?<Close>{CloseMarkup})";
    private static readonly string LINES = @"(?<Lines>[0-9]*,? ?[0-9]*)";
    private static readonly string LABEL = $"(?<Label>.+)";
    private static readonly string TABS = @"(?<Tabs>[\t\s]*)";
    private static readonly string HEADER = $"(?<Header>{OPEN}{LINES}:?{LABEL}{CLOSE})";
    public static readonly string Pattern = $"^{TABS}{HEADER}";
}

public static class DocFilesPatterns
{
    private static readonly string SpacesOrTabs = @"[\s\t]";
    private static readonly string Period = @"\.";
    private static readonly string Integer = @"[0-9]*";
    private static readonly string NotWordOrPeriod = $"[^A-Za-z0-9{Period}]*";
    private static readonly string WordChars = @"[A-Za-z0-9]";
    private static readonly string SPACE = $"{SpacesOrTabs}*";
    private static readonly string FILENUMBER = $"(?<FileNumber>{Integer} ?-?)";
    private static readonly string PAGE = @"(?<Page>[A-Za-z0-9\(\)\s]+)";
    private static readonly string SUMMARY = $"(?<Summary>{NotWordOrPeriod}{PAGE}{NotWordOrPeriod})";
    private static readonly string EXT = $"(?<Ext>{Period}*{WordChars}*)";
    public static readonly string Pattern = $"^{SPACE}{FILENUMBER}{SPACE}{SUMMARY}{SPACE}{EXT}";
```
