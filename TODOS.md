* Refactor FileGraphInfo to include Id, Nested Id, and possibly RelativeDir.  Move out of TemplateHelper.
* Redo nested logic by using a stack that contains an additional scope type.
* Determine code snippet types by extension.
* Determine whether to include document content of src path (for images) based on extension type.