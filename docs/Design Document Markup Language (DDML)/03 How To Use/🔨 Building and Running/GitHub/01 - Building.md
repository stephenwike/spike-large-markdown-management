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