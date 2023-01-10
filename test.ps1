<#
.SYNOPSIS
    Test the track's exercises.
.DESCRIPTION
    Test the track's exercises for correctness.
.EXAMPLE
    The example below will verify all exercises
    PS C:\> ./test.ps1
#>

$ErrorActionPreference = "Stop"

$buildDir = Join-Path $PSScriptRoot "build"

Write-Output "Clean"
Remove-Item -Recurse -Force $buildDir -ErrorAction Ignore

Write-Output "Copy"
Copy-Item (Join-Path $PSScriptRoot "exercises" "practice") -Destination $buildDir -Recurse

Write-Output "Prepare"
Get-ChildItem -Path $buildDir -Directory | ForEach-Object {
    $pascalName = (Get-Culture).TextInfo.ToTitleCase(($_.Name.ToLower() -Replace "-", " ")) -Replace " ", ""
    
    # Unskip tests
    $testsFile = Join-Path $_.FullName "${pascalName}Tests.vb"
    (Get-Content $testsFile) -Replace "\(Skip:=""Remove this Skip property to run this test""\)", "" | Set-Content $testsFile

    # Replace stub with example
    Move-Item -Path (Join-Path $_.FullName ".meta" "Example.vb") -Destination (Join-Path $_.FullName "${pascalName}.vb") -Force
}

Write-Output "Test"
dotnet test (Join-Path $buildDir "Practice.sln")
exit $LastExitCode
