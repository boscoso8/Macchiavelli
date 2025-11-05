#!/usr/bin/env pwsh
# Build script for Macchiavelli on Windows 11 x64

Write-Host "====================================" -ForegroundColor Cyan
Write-Host "Building Macchiavelli for Windows 11 x64" -ForegroundColor Cyan
Write-Host "====================================" -ForegroundColor Cyan
Write-Host ""

Set-Location src/Macchiavelli

Write-Host "Building project..." -ForegroundColor Yellow
dotnet build -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "Build successful!" -ForegroundColor Green
Write-Host ""
Write-Host "Publishing standalone executable..." -ForegroundColor Yellow

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishReadyToRun=true

if ($LASTEXITCODE -ne 0) {
    Write-Host "Publish failed!" -ForegroundColor Red
    Read-Host "Press Enter to exit"
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "====================================" -ForegroundColor Cyan
Write-Host "Build Complete!" -ForegroundColor Green
Write-Host "====================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Executable location:" -ForegroundColor Yellow
Write-Host "src/Macchiavelli/bin/Release/net9.0-windows/win-x64/publish/Macchiavelli.exe" -ForegroundColor White
Write-Host ""
Read-Host "Press Enter to exit"
