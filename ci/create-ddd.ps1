Push-Location ./docs/ddd
    $dddContent = Get-Content ../ddd.md
    $files = Get-ChildItem -Recurse -Include *.md -Name
    foreach ($file in $files)
    {
        $content = Get-Content $file -Raw
        $dddContent.replace("<|$file|>", "$content")
    }
    Set-Content ../dddmd $dddContent
    
Pop-Location
