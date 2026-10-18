param(
    [string]$UnityPath = 'C:/Program Files/Unity/Hub/Editor/6000.3.24f1/Editor/Unity.exe'
)

$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path -Parent $PSScriptRoot
$exportDirectory = Join-Path $projectRoot 'Exports'
$downloadDirectory = Join-Path $projectRoot 'Downloads'
$packagePath = Join-Path $downloadDirectory 'TerrainLab-Students.unitypackage'
$logPath = Join-Path $exportDirectory 'package-export.log'

if (!(Test-Path -LiteralPath $UnityPath)) { throw "Unity not found: $UnityPath" }
if (Test-Path -LiteralPath (Join-Path $projectRoot 'Temp/UnityLockfile')) {
    throw 'Close this project in Unity before exporting from the command line.'
}
New-Item -ItemType Directory -Force -Path $exportDirectory | Out-Null
New-Item -ItemType Directory -Force -Path $downloadDirectory | Out-Null
# Export only the workshop content. Unity preserves GUIDs and builds the native package archive.
$unityArguments = @(
    '-batchmode', '-nographics', '-quit',
    '-projectPath', ('"' + $projectRoot + '"'),
    '-exportPackage',
    'Assets/Scenes/TerrainClassroom.unity',
    'Assets/Scenes/TerrainFinalized.unity',
    'Assets/Player',
    'Assets/Scripts/ClassroomFirstPersonController.cs',
    'Assets/InputSystem_Actions.inputactions',
    'Assets/TerrainClassroom/Layers',
    'Assets/TerrainFinalized',
    # Select the student exercise explicitly so teacher notes cannot enter through this folder.
    'Assets/TerrainLab/START_HERE.md',
    ('"' + $packagePath + '"'),
    '-logFile', ('"' + $logPath + '"')
)
$started = Get-Date
$process = Start-Process -FilePath $UnityPath -ArgumentList $unityArguments -WindowStyle Hidden -Wait -PassThru
if ($process.ExitCode -ne 0) { throw "Unity export failed ($($process.ExitCode)); see $logPath" }
if (!(Test-Path -LiteralPath $packagePath)) { throw "Package missing; see $logPath" }
$package = Get-Item -LiteralPath $packagePath
if ($package.Length -eq 0 -or $package.LastWriteTime -lt $started) { throw 'Export did not produce a fresh package.' }
Write-Output "Created $packagePath ($([Math]::Round($package.Length / 1MB, 1)) MB)"
