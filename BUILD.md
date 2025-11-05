# Building for Windows 11 x64

This document describes how to build Macchiavelli for Windows 11 x64 platform.

## Build Output

The project produces a self-contained, single-file Windows executable:
- **Target Platform**: Windows 11 x64
- **Runtime**: .NET 9.0 (self-contained)
- **Executable Type**: Single file, ready-to-run
- **Expected Size**: ~75-80 MB

## Build Methods

### Method 1: Using Build Scripts (Recommended)

**Option A: Batch File (Windows Command Prompt)**
```cmd
build.bat
```

**Option B: PowerShell Script**
```powershell
.\build.ps1
```

Both scripts will:
1. Build the project in Release configuration
2. Publish a self-contained executable for win-x64
3. Display the output location

### Method 2: Using .NET CLI Directly

**Quick Build:**
```bash
dotnet build -c Release
```

**Full Publish (creates standalone .exe):**
```bash
cd src/Macchiavelli
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishReadyToRun=true
```

**Output Location:**
```
src/Macchiavelli/bin/Release/net9.0-windows/win-x64/publish/Macchiavelli.exe
```

### Method 3: Using Visual Studio 2022

1. Open `Macchiavelli.sln` in Visual Studio 2022
2. Set build configuration to **Release**
3. Right-click the project → **Publish**
4. Select "Folder" as the target
5. Configure:
   - Target Framework: net9.0-windows
   - Deployment Mode: Self-contained
   - Target Runtime: win-x64
   - File Publish Options: Produce single file
6. Click **Publish**

## Build Configuration

The project file (`Macchiavelli.csproj`) is configured with:

```xml
<PropertyGroup>
  <TargetFramework>net9.0-windows</TargetFramework>
  <RuntimeIdentifier>win-x64</RuntimeIdentifier>
  <PlatformTarget>x64</PlatformTarget>
  <SelfContained>true</SelfContained>
  <PublishSingleFile>true</PublishSingleFile>
  <PublishReadyToRun>true</PublishReadyToRun>
</PropertyGroup>
```

### Configuration Explanation

- **TargetFramework**: Targets Windows-specific .NET 9.0
- **RuntimeIdentifier**: Specifies Windows x64 platform
- **PlatformTarget**: Ensures x64 compilation
- **SelfContained**: Includes .NET runtime in the executable
- **PublishSingleFile**: Creates a single .exe file
- **PublishReadyToRun**: Pre-compiles for faster startup

## Distribution

The generated `Macchiavelli.exe` is:
- ✅ Self-contained (no .NET installation required)
- ✅ Single file (easy to distribute)
- ✅ Optimized for Windows 11 x64
- ✅ Ready-to-run (faster startup time)

Users can simply:
1. Download `Macchiavelli.exe`
2. Double-click to run
3. No installation or dependencies required

## System Requirements

**For Running:**
- Windows 11 x64
- No additional software required

**For Building:**
- Windows 10/11 x64
- .NET 9.0 SDK or later
- (Optional) Visual Studio 2022 or VS Code

## Troubleshooting Build Issues

**Issue**: "dotnet command not found"
- Install .NET 9.0 SDK from https://dotnet.microsoft.com/download/dotnet/9.0

**Issue**: Build takes a long time
- This is normal for the first build with ReadyToRun enabled
- Subsequent builds will be faster

**Issue**: Executable size is large
- This is expected for self-contained applications
- The .NET runtime is embedded in the executable
- Consider trimming if size is critical (may affect reflection-based features)

## Advanced Build Options

### Trimmed Build (Smaller Size)
```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=true
```
⚠️ Warning: Trimming may remove reflection-based features

### Debug Build
```bash
dotnet build -c Debug
```

### Testing Without Publishing
```bash
cd src/Macchiavelli
dotnet run
```

## CI/CD Integration

For automated builds, use:
```yaml
- name: Build Macchiavelli
  run: |
    cd src/Macchiavelli
    dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:PublishReadyToRun=true
    
- name: Upload Artifact
  uses: actions/upload-artifact@v3
  with:
    name: Macchiavelli-Windows-x64
    path: src/Macchiavelli/bin/Release/net9.0-windows/win-x64/publish/Macchiavelli.exe
```
