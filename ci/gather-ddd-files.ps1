Push-Location ./docs/ddd
    $files = Get-ChildItem -Path ./ -Recurse -Name -Include *.md 
    Write-Output "::set-output name=files::$files"
Pop-Location
