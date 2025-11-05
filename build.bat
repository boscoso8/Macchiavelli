@echo off
REM Build script for Macchiavelli on Windows 11 x64

echo ====================================
echo Building Macchiavelli for Windows 11 x64
echo ====================================
echo.

cd src\Macchiavelli

echo Building project...
dotnet build -c Release

if %ERRORLEVEL% NEQ 0 (
    echo Build failed!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo Build successful!
echo.
echo Publishing standalone executable...

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishReadyToRun=true

if %ERRORLEVEL% NEQ 0 (
    echo Publish failed!
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ====================================
echo Build Complete!
echo ====================================
echo.
echo Executable location:
echo src\Macchiavelli\bin\Release\net9.0-windows\win-x64\publish\Macchiavelli.exe
echo.
pause
