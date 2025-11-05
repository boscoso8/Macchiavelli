namespace Macchiavelli;

public class Game
{
    private List<Player> players;
    private Deck deck;
    private List<Meld> table;
    private int currentPlayerIndex;
    private bool gameOver;

    public Game()
    {
        players = new List<Player>();
        deck = new Deck(2); // Use 2 decks for Macchiavelli
        table = new List<Meld>();
        currentPlayerIndex = 0;
        gameOver = false;
    }

    public void Initialize()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("   MACCHIAVELLI CARD GAME");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine("Welcome to Macchiavelli!");
        Console.WriteLine("A rummy-style card game where you form sets and runs.");
        Console.WriteLine();

        // Get number of players
        int numPlayers;
        while (true)
        {
            Console.Write("Enter number of players (2-4): ");
            if (int.TryParse(Console.ReadLine(), out numPlayers) && numPlayers >= 2 && numPlayers <= 4)
                break;
            Console.WriteLine("Please enter a number between 2 and 4.");
        }

        // Create players
        for (int i = 0; i < numPlayers; i++)
        {
            Console.Write($"Enter name for Player {i + 1}: ");
            string name = Console.ReadLine() ?? $"Player {i + 1}";
            players.Add(new Player(name));
        }

        // Shuffle and deal cards
        deck.Shuffle();
        int cardsPerPlayer = 13;
        
        for (int i = 0; i < cardsPerPlayer; i++)
        {
            foreach (var player in players)
            {
                Card? card = deck.Draw();
                if (card != null)
                    player.AddCard(card);
            }
        }

        // Sort all hands
        foreach (var player in players)
        {
            player.SortHand();
        }

        Console.WriteLine("\nGame initialized! Cards have been dealt.");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
    }

    public void Play()
    {
        while (!gameOver)
        {
            PlayTurn();
        }

        AnnounceWinner();
    }

    private void PlayTurn()
    {
        Console.Clear();
        Player currentPlayer = players[currentPlayerIndex];

        Console.WriteLine("=================================");
        Console.WriteLine($"   {currentPlayer.Name}'s Turn");
        Console.WriteLine("=================================");
        Console.WriteLine();

        // Show table
        DisplayTable();

        // Show player's hand
        currentPlayer.DisplayHand();

        Console.WriteLine("\nOptions:");
        Console.WriteLine("1. Draw a card");
        Console.WriteLine("2. Play a meld (set or run)");
        Console.WriteLine("3. Add to existing meld");
        Console.WriteLine("4. Discard and end turn");
        Console.WriteLine("5. Sort hand");
        Console.Write("\nSelect an option (1-5): ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                DrawCard(currentPlayer);
                break;
            case "2":
                PlayMeld(currentPlayer);
                break;
            case "3":
                AddToMeld(currentPlayer);
                break;
            case "4":
                DiscardCard(currentPlayer);
                NextPlayer();
                break;
            case "5":
                currentPlayer.SortHand();
                Console.WriteLine("Hand sorted!");
                Thread.Sleep(1000);
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(1000);
                break;
        }

        // Check if player won
        if (currentPlayer.Hand.Count == 0)
        {
            gameOver = true;
        }
    }

    private void DrawCard(Player player)
    {
        Card? card = deck.Draw();
        if (card != null)
        {
            player.AddCard(card);
            Console.WriteLine($"\nYou drew: {card}");
        }
        else
        {
            Console.WriteLine("\nThe deck is empty!");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void PlayMeld(Player player)
    {
        Console.WriteLine("\nCreate a meld:");
        Console.WriteLine("1. Run (sequence of same suit)");
        Console.WriteLine("2. Set (same rank, different suits)");
        Console.Write("Select type (1-2): ");

        string? typeInput = Console.ReadLine();
        MeldType type = typeInput == "1" ? MeldType.Run : MeldType.Set;

        Meld meld = new Meld(type);

        Console.WriteLine("\nEnter card numbers from your hand (comma-separated, e.g., 1,2,3):");
        string? cardInput = Console.ReadLine();

        if (string.IsNullOrEmpty(cardInput))
        {
            Console.WriteLine("No cards selected.");
            Thread.Sleep(1000);
            return;
        }

        try
        {
            string[] indices = cardInput.Split(',');
            List<Card> selectedCards = new List<Card>();

            foreach (string indexStr in indices)
            {
                if (int.TryParse(indexStr.Trim(), out int index) && index > 0 && index <= player.Hand.Count)
                {
                    selectedCards.Add(player.Hand[index - 1]);
                }
            }

            foreach (var card in selectedCards)
            {
                meld.AddCard(card);
            }

            if (meld.IsValid())
            {
                table.Add(meld);
                foreach (var card in selectedCards)
                {
                    player.RemoveCard(card);
                }
                Console.WriteLine("\nMeld played successfully!");
            }
            else
            {
                Console.WriteLine("\nInvalid meld! Must have at least 3 cards in proper sequence or set.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void AddToMeld(Player player)
    {
        if (table.Count == 0)
        {
            Console.WriteLine("\nNo melds on the table yet!");
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine("\nSelect a meld to add to (or 0 to cancel):");
        Console.Write("Meld number: ");
        
        if (!int.TryParse(Console.ReadLine(), out int meldIndex) || meldIndex < 0 || meldIndex > table.Count)
        {
            Console.WriteLine("Invalid meld number.");
            Thread.Sleep(1000);
            return;
        }

        if (meldIndex == 0)
            return;

        Console.Write("Enter card number from your hand: ");
        if (!int.TryParse(Console.ReadLine(), out int cardIndex) || cardIndex < 1 || cardIndex > player.Hand.Count)
        {
            Console.WriteLine("Invalid card number.");
            Thread.Sleep(1000);
            return;
        }

        Card card = player.Hand[cardIndex - 1];
        Meld meld = table[meldIndex - 1];
        meld.AddCard(card);

        if (meld.IsValid())
        {
            player.RemoveCard(card);
            Console.WriteLine("\nCard added to meld successfully!");
        }
        else
        {
            meld.Cards.Remove(card);
            Console.WriteLine("\nCannot add that card to this meld!");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DiscardCard(Player player)
    {
        if (player.Hand.Count == 0)
        {
            Console.WriteLine("\nNo cards to discard!");
            Thread.Sleep(1000);
            return;
        }

        Console.Write("\nEnter card number to discard (or 0 to skip): ");
        if (int.TryParse(Console.ReadLine(), out int cardIndex) && cardIndex > 0 && cardIndex <= player.Hand.Count)
        {
            Card card = player.Hand[cardIndex - 1];
            player.RemoveCard(card);
            Console.WriteLine($"Discarded: {card}");
        }

        Console.WriteLine("Turn ended.");
        Thread.Sleep(1000);
    }

    private void NextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
    }

    private void DisplayTable()
    {
        Console.WriteLine("TABLE:");
        if (table.Count == 0)
        {
            Console.WriteLine("(empty)");
        }
        else
        {
            for (int i = 0; i < table.Count; i++)
            {
                table[i].Display(i + 1);
            }
        }
        Console.WriteLine();
    }

    private void AnnounceWinner()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("      GAME OVER!");
        Console.WriteLine("=================================");
        Console.WriteLine();

        Player winner = players[currentPlayerIndex];
        Console.WriteLine($"🎉 {winner.Name} wins! 🎉");
        Console.WriteLine();

        Console.WriteLine("Final Scores:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.Hand.Count} cards remaining");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
