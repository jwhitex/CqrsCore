$solutionPath = split-path $MyInvocation.MyCommand.Definition
$getDotNet = join-path $solutionPath "tools\install.ps1"

$env:DOTNET_INSTALL_DIR="$(Convert-Path "$PSScriptRoot")\.dotnet\win7-x64"
if (!(Test-Path $env:DOTNET_INSTALL_DIR))
{
    mkdir $env:DOTNET_INSTALL_DIR | Out-Null
}
    
& $getDotNet

$env:PATH = "$env:DOTNET_INSTALL_DIR;$env:PATH"
$dotnet = "$env:DOTNET_INSTALL_DIR\dotnet"

# Restore packages and build product
& $dotnet restore -v Minimal # Restore all packages
if ($LASTEXITCODE -ne 0)
{
    throw "dotnet restore failed with exit code $LASTEXITCODE"
}

# Build all
dir "src/CqrsCore*" | where {$_.PsIsContainer} |
foreach {
        & $dotnet build "$_"
}

# # Run tests
# dir "*.Tests*" | where {$_.PsIsContainer} |
# foreach {
#     & $dotnet test "$_"
# }

# Package all
$revision = @{ $true = $env:APPVEYOR_BUILD_NUMBER; $false = 1 }[$env:APPVEYOR_BUILD_NUMBER -ne $NULL];
$revision = "{0:D4}" -f [convert]::ToInt32($revision, 10)

dir "src/*" | where {$_.PsIsContainer -and $_ -NotLike "*.Tests*" } |
foreach {
        & $dotnet pack "$_" -c Release -o .\.nupkg\ --version-suffix=$revision
}
