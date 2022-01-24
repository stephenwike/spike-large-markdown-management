Push-Location ./docs/ddd
    $foo = Get-ChildItem -Recurse -Include *.md -Name
    Write-Host $foo
    Write-Host "END OF LIST"
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
