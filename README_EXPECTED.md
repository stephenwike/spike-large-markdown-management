# DesignDoc Markup Language (DDML)

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

INSERT TEMPLATE EXAMPLE HERE

</details>


## 🚧 Reserved Markup

|Tag|Example|Type|Desciption|
|---|---|---|---|
|::|::MyHeading::|Directory|This is a standard folder include.  Creates a heading.|
|::|::MyContent::|File|This is a standard content include.  Creates a heading.|
|[:, :]|[:MyCollapsed:]|File|This is a collapsed content include.|
|!:, :!|!:./src/MyFile.ext:!|Get content from specified file.|
|!:n,m:, :!|!:3,15:./src/MyFile.ext:!|Get content from specified file.|


## 🔨 Building and Running


<details>
<summary>Nuget</Summary>
<blockquote>

<details id="building-nuget">
<summary>Building</summary>

TODO

</details>

<details id="running-nuget">
<summary>Running</summary>

TODO

</details>

</blockquote>
</details>


<details>
<summary>GitHub</Summary>
<blockquote>

<details id="building-github">
<summary>Building</summary>

From the DesignDocMarkupLanguage project directory run:

```cmd
dotnet pack
```

</details>

<details id="running-github">
<summary>Running</summary>

From the project root:

```cmd
dotnet tool install --global --add-source src\DesignDocMarkupLanguage\nupkg DesignDocMarkupLanguage
```

> You can invoke the tool using the following command: ddml
> Tool 'designdocmarkuplanguage' (version '1.0.0') was successfully installed.

</details>

</blockquote>
</details>

## Showing Example Code

You can include example code by providing the source filepath and optionally specifying which lines to display.

### Regex Patterns Used

Here are the regex patterns used for determining markup compatibility.

!:3,41:../src/DesignDocMarkupLanguage/Constants/Patterns.cs:!