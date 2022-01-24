Push-Location ./docs/ddd
    dir
    $dddContent = Get-Content ../ddd-template.md
    $files = Get-ChildItem -Recurse -Include *.md -Name
    foreach ($file in $files)
    {
        $content = Get-Content $file -Raw
        $dddContent = $dddContent.replace("<|$file|>", "$content")
        echo "<|$file|>"
    }
    Set-Content ../ddd.md $dddContent
    
Pop-Location
