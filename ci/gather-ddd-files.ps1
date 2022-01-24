Push-Location ./docs/ddd
    $files = Get-ChildItem -Path ./ -Recurse -Name 
    Write-Output "::set-output name=files::$files"
Pop-Location
