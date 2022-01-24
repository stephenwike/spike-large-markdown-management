Push-Location ./docs/ddd
    $files = Get-ChildItem -Path ./ -Recurse -Name 
    Write-Output $files
Pop-Location
