Push-Location ./docs/ddd
    $ddd = Get-ChildItem ../ddd.md -File
    $files = Get-ChildItem -Recurse -Include *.md -Name
    foreach ($file in $files)
    {
        $content = Get-Content $file -Raw
        $ddd -match "<|$file|>" -replace "$content" | Set-Content $ddd
    } 
Pop-Location
