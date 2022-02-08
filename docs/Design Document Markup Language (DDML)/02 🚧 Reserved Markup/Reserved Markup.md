|Tag|Example|Type|Desciption|
|---|---|---|---|
|::|::MyHeading::|Directory|This is a standard folder include.  Creates a heading.|
|::|::MyContent::|File|This is a standard content include.  Creates a heading.|
|[:, :]|[:MyCollapsed:]|File|This is a collapsed content include.|
|!:, :!|!:./src/MyFile.ext:!|File|Get content from specified file.|
|!:n,m:, :!|!:3,15:./src/MyFile.ext:!|File|Get content from specified file.|
|->|::MyDir->MyFile::|File|Bypass parent directory.  Used to control order of content between multiple parent directories.|
