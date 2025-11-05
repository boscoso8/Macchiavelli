# Quick Start Guide

## For Users (Playing the Game)

### Option 1: Download Pre-built Executable (Recommended)
1. Download `Macchiavelli.exe` from the releases page
2. Double-click `Macchiavelli.exe` to run
3. Follow the on-screen instructions

### Option 2: Build from Source
1. Install [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
2. Clone this repository
3. Run `build.bat` (or `build.ps1` for PowerShell)
4. Find the executable in `src/Macchiavelli/bin/Release/net9.0-windows/win-x64/publish/Macchiavelli.exe`

## For Developers

### Prerequisites
- Windows 11 x64
- .NET 9.0 SDK or later
- (Optional) Visual Studio 2022 or VS Code with C# extension

### Development Setup
```bash
# Clone the repository
git clone https://github.com/boscoso8/Macchiavelli.git
cd Macchiavelli

# Restore dependencies
cd src/Macchiavelli
dotnet restore

# Build
dotnet build

# Run in development mode
dotnet run
```

### Project Commands

**Build for development:**
```bash
dotnet build
```

**Run the game:**
```bash
dotnet run
```

**Build release version:**
```bash
dotnet build -c Release
```

**Create standalone executable:**
```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

### Testing the Game
Since this is a console-based interactive game, testing is primarily manual:
1. Run `dotnet run` in the project directory
2. Test with different numbers of players (2-4)
3. Try creating different types of melds (runs and sets)
4. Verify card validation logic
5. Test end-game conditions

## Game Controls

When playing:
- Use number keys to select menu options
- Enter card numbers separated by commas when creating melds
- Follow on-screen prompts

## Troubleshooting

**Problem**: "dotnet: command not found"
- **Solution**: Install .NET 9.0 SDK from https://dotnet.microsoft.com/download/dotnet/9.0

**Problem**: Game window closes immediately
- **Solution**: Run from Command Prompt or PowerShell instead of double-clicking

**Problem**: Unicode symbols not displaying correctly
- **Solution**: Use Windows Terminal or a console that supports UTF-8 encoding

## Architecture

The game is built using object-oriented design:
- **Card**: Represents a playing card with suit and rank
- **Deck**: Manages the card deck with shuffling and drawing
- **Player**: Manages player hand and actions
- **Meld**: Validates sets and runs
- **Game**: Controls game flow and rules

## Performance

- Startup time: < 1 second
- Memory usage: ~ 20-30 MB
- Executable size: ~ 70-80 MB (includes .NET runtime)
