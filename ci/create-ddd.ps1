Push-Location ./docs/ddd
    $ddd = Get-ChildItem ddd.md
    $files = Get-ChildItem -Recurse -Include *.md
    foreach ($file in $files)
    {
        $content = Get-Content $file
        $name = Get-ChildItem $file -Name
        $ddd -match "<|$name|>" -replace "$content"
    } 
Pop-Location
