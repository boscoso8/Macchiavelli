# Macchiavelli

Macchiavelli is an Italian rummy-style card game implementation for Windows 11 x64.

## About the Game

Macchiavelli is a popular Italian card game similar to Rummy. Players aim to form melds (sets and runs) with their cards. The first player to play all their cards wins!

### Game Rules

- **Players**: 2-4 players
- **Deck**: 2 standard 52-card decks (104 cards total)
- **Initial Deal**: Each player receives 13 cards
- **Objective**: Be the first to play all your cards by forming valid melds

**Meld Types**:
- **Run**: Three or more consecutive cards of the same suit (e.g., 3♥ 4♥ 5♥)
- **Set**: Three or four cards of the same rank with different suits (e.g., 7♥ 7♦ 7♣)

## System Requirements

- Windows 11 x64
- .NET 9.0 Runtime (included in self-contained build)

## Building from Source

### Prerequisites
- .NET 9.0 SDK or later
- Windows 11 x64

### Build Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/boscoso8/Macchiavelli.git
   cd Macchiavelli
   ```

2. Build the project:
   ```bash
   cd src/Macchiavelli
   dotnet build
   ```

3. Run the game:
   ```bash
   dotnet run
   ```

### Publishing for Distribution

To create a standalone executable for Windows 11 x64:

```bash
cd src/Macchiavelli
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

The executable will be generated at:
```
src/Macchiavelli/bin/Release/net9.0-windows/win-x64/publish/Macchiavelli.exe
```

## How to Play

1. Launch `Macchiavelli.exe`
2. Enter the number of players (2-4)
3. Enter player names
4. Cards are automatically dealt

### During Your Turn

Choose from the following options:
1. **Draw a card** - Draw a card from the deck
2. **Play a meld** - Create a new set or run on the table
3. **Add to existing meld** - Add a card to a meld already on the table
4. **Discard and end turn** - Discard a card and pass to the next player
5. **Sort hand** - Reorganize your cards by suit and rank

### Winning

The first player to play all their cards wins the game!

## Technical Details

- **Platform**: Windows 11 x64
- **Framework**: .NET 9.0
- **Language**: C#
- **Architecture**: Self-contained, single-file executable
- **UI**: Console-based with Unicode card symbols

## Project Structure

```
Macchiavelli/
├── src/
│   └── Macchiavelli/
│       ├── Card.cs          # Card representation
│       ├── Deck.cs          # Deck management
│       ├── Player.cs        # Player management
│       ├── Meld.cs          # Meld validation
│       ├── Game.cs          # Game logic and flow
│       ├── Program.cs       # Entry point
│       └── Macchiavelli.csproj
├── LICENSE
└── README.md
```

## License

See LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
