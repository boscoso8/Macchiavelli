namespace Macchiavelli;

public enum MeldType
{
    Run,      // Sequence of same suit (e.g., 3♥ 4♥ 5♥)
    Set       // Same rank different suits (e.g., 7♥ 7♦ 7♣)
}

public class Meld
{
    public MeldType Type { get; }
    public List<Card> Cards { get; }

    public Meld(MeldType type)
    {
        Type = type;
        Cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        Cards.Add(card);
    }

    public bool IsValid()
    {
        if (Cards.Count < 3)
            return false;

        if (Type == MeldType.Set)
        {
            // All cards must have same rank and different suits
            Rank rank = Cards[0].Rank;
            HashSet<Suit> suits = new HashSet<Suit>();
            
            foreach (var card in Cards)
            {
                if (card.Rank != rank || suits.Contains(card.Suit))
                    return false;
                suits.Add(card.Suit);
            }
            return true;
        }
        else // Run
        {
            // All cards must be same suit and consecutive ranks
            Cards.Sort((c1, c2) => c1.Rank.CompareTo(c2.Rank));
            
            Suit suit = Cards[0].Suit;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Suit != suit)
                    return false;
                    
                if (i > 0 && (int)Cards[i].Rank != (int)Cards[i - 1].Rank + 1)
                    return false;
            }
            return true;
        }
    }

    public void Display(int index)
    {
        string typeStr = Type == MeldType.Run ? "Run" : "Set";
        Console.Write($"Meld {index} ({typeStr}): ");
        foreach (var card in Cards)
        {
            Console.Write($"{card} ");
        }
        Console.WriteLine();
    }
}
