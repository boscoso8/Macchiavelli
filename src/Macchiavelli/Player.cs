namespace Macchiavelli;

public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void AddCard(Card card)
    {
        Hand.Add(card);
    }

    public void RemoveCard(Card card)
    {
        Hand.Remove(card);
    }

    public void SortHand()
    {
        Hand.Sort((c1, c2) =>
        {
            int suitCompare = c1.Suit.CompareTo(c2.Suit);
            if (suitCompare != 0)
                return suitCompare;
            return c1.Rank.CompareTo(c2.Rank);
        });
    }

    public void DisplayHand()
    {
        Console.WriteLine($"\n{Name}'s Hand:");
        for (int i = 0; i < Hand.Count; i++)
        {
            Console.Write($"[{i + 1}] {Hand[i]} ");
            if ((i + 1) % 10 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }
}
