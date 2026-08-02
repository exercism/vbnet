<#
.SYNOPSIS
    Verify the track's exercises.
.DESCRIPTION
    Verify the track's exercises.
    This script verifies that:
    - The example implementations pass the test suites
    - The refactoring projects stub files pass the test suites
.PARAMETER Exercise
    The slug of the exercise to verify (optional).
.EXAMPLE
    The example below will verify the full solution
    PS C:\> ./bin/test.ps1
.EXAMPLE
    The example below will verify the "acronym" exercise
    PS C:\> ./bin/test.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. (Join-Path $PSScriptRoot "shared.ps1")

function Clean($BuildDir) {
    Write-Output "Cleaning previous build"
    Remove-Item -Recurse -Force $BuildDir -ErrorAction Ignore
}

function Copy-Exercises($SourceDir, $BuildDir) {
    Write-Output "Copying exercises"
    Copy-Item $SourceDir -Destination $BuildDir -Recurse
}

function Copy-SingleExercise($SourceDir, $PracticeExercisesDir, $Exercise) {
    $exerciseDir = Join-Path $SourceDir "practice" $Exercise
    if (-Not (Test-Path $exerciseDir)) {
        throw "Could not find exercise '$Exercise'"
    }

    Write-Output "Copying $Exercise exercise"
    New-Item -ItemType Directory -Force $PracticeExercisesDir | Out-Null
    Copy-Item $exerciseDir -Destination $PracticeExercisesDir -Recurse
}

function Enable-All-UnitTests($BuildDir) {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $BuildDir -Include "*Tests.vb" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -Replace "\(Skip:=""Remove this Skip property to run this test""\)", "" | Set-Content $_.FullName
    }
}

function Set-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ExercisesDir, $ReplaceFileName)

    if ($PSCmdlet.ShouldProcess("Exercise $ReplaceFileName", "replace solution with example")) {
        Get-ChildItem -Path $ExercisesDir -Include "*.vbproj" -Recurse | ForEach-Object {
            $stub = Join-Path -Path $_.Directory ($_.BaseName + ".vb")
            $example = Join-Path -Path $_.Directory ".meta" $ReplaceFileName

            Move-Item -Path $example -Destination $stub -Force
        }
    }
}

function Use-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($PracticeExercisesDir)

    if ($PSCmdlet.ShouldProcess("Exercises directory", "replace all solutions with corresponding examples")) {
        Write-Output "Replacing practice exercise stub(s) with example"
        Set-ExampleImplementation $PracticeExercisesDir "Example.vb"
    }
}

function Test-ExerciseImplementation($Exercise, $BuildDir, $PracticeExercisesDir) {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        Invoke-CallScriptExitOnError { dotnet test "$BuildDir/Exercises.slnx" }
    }
    elseif (Test-Path "$PracticeExercisesDir/$Exercise") {
        Invoke-CallScriptExitOnError { dotnet test "$PracticeExercisesDir/$Exercise" }
    }
    else {
        throw "Could not find exercise '$Exercise'"
    }
}


$repoRoot = Split-Path -Parent $PSScriptRoot
$buildDir = Join-Path $repoRoot "build"
$practiceExercisesDir = Join-Path $buildDir "practice"
$sourceDir = Join-Path $repoRoot "exercises"

Clean $buildDir
if ($Exercise) {
    Copy-SingleExercise $sourceDir $practiceExercisesDir $Exercise
} else {
    Copy-Exercises $sourceDir $buildDir
}
Enable-All-UnitTests $buildDir
Use-ExampleImplementation $practiceExercisesDir
Test-ExerciseImplementation -Exercise $Exercise -BuildDir $buildDir -PracticeExercisesDir $practiceExercisesDir

exit $LastExitCode
