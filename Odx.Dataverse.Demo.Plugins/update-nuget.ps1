[Reflection.Assembly]::LoadWithPartialName('System.IO.Compression')

$zipfile = '\bin\Debug\Odx.Dataverse.Demo.Plugins.1.0.0.nupkg'
$scriptPath = Join-Path $PSScriptRoot $zipfile
$files   = 'Microsoft.Xrm.Sdk.dll'

$stream = New-Object IO.FileStream($scriptPath, [IO.FileMode]::Open)
$mode   = [IO.Compression.ZipArchiveMode]::Update
$zip    = New-Object IO.Compression.ZipArchive($stream, $mode)

($zip.Entries | ? { $files -contains $_.Name }) | % { $_.Delete() }

$zip.Dispose()
$stream.Close()
$stream.Dispose()