# (DDML) DesignDoc Markup Language

This markup language is designed to templatize GitHub style markdown files commonly used in repository documentation.

## Random Collection of functional reqs

* Templates should only have one tag per line.
* Collapsable tags will automatically form blockquotes when nested.

## Building the tool

From the DesignDocMarkupLanguage project directory run:

```cmd
dotnet pack
```

## Using tool from project - globally:

From the project root:

```cmd
dotnet tool install --global --add-source src\DesignDocMarkupLanguage\nupkg DesignDocMarkupLanguage
```

> You can invoke the tool using the following command: ddml
> Tool 'designdocmarkuplanguage' (version '1.0.0') was successfully installed.


```c