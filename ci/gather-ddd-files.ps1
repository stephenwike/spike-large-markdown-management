Push-Location ./docs/ddd
    $files = Get-ChildItem -Recurse -Include *.md -Name | 
    ForEach-Object -Process {Join-Path -Path "docs/ddd" -ChildPath $_}
    Write-Output "::set-output name=files::$files"
Pop-Location
