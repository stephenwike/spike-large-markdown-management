::Design Document Markup Language (DDML)::

This markup language is designed to templatize markdown files commonly used in repository documentation. This way, large markdown documents can be broken down into maintainable sized files and compiled into a final document. 

**This document was generated using the DDML tool.**

    ::Project Organization::
        [:Component File Management:]
        [:Template File:]
        [:Template Rules:]
        [:Template Example:]

    ::Reserved Markup::
        ::Reserved Markup::

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

!:3,42:./src/DesignDocMarkupLanguage/Constants/Patterns.cs:!