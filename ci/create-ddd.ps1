Push-Location ./docs/ddd
    $ddd = Get-ChildItem ddd.md
    $files = Get-ChildItem -Recurse -Include *.md -Name
    foreach ($file in $files)
    {
        $content = Get-Content $file
        $ddd -match "<|$file|>" -replace "$content"
    } 
Pop-Location
