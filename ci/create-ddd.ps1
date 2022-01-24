Push-Location ./docs/ddd
    $dddContent = Get-Content ../ddd-template.md
    $files = Get-ChildItem -Recurse -Include *.md -Name
    foreach ($file in $files)
    {
        $content = Get-Content $file -Raw
        $dddContent = $dddContent.replace("<|$file|>", "$content")
    }
    Set-Content ../ddd.md $dddContent
    
Pop-Location
