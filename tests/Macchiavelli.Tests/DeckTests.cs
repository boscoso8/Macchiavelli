namespace Macchiavelli.Tests;

public class DeckTests
{
    [Fact]
    public void Deck_WithOneStandardDeck_ShouldHave52Cards()
    {
        // Arrange & Act
        var deck = new Deck(1);

        // Assert
        Assert.Equal(52, deck.Count);
    }

    [Fact]
    public void Deck_WithTwoDecks_ShouldHave104Cards()
    {
        // Arrange & Act
        var deck = new Deck(2);

        // Assert
        Assert.Equal(104, deck.Count);
    }

    [Fact]
    public void Deck_Draw_ShouldReduceCardCount()
    {
        // Arrange
        var deck = new Deck(1);
        int initialCount = deck.Count;

        // Act
        var card = deck.Draw();

        // Assert
        Assert.NotNull(card);
        Assert.Equal(initialCount - 1, deck.Count);
    }

    [Fact]
    public void Deck_DrawAllCards_ShouldReturnNull()
    {
        // Arrange
        var deck = new Deck(1);
        
        // Act - Draw all cards
        for (int i = 0; i < 52; i++)
        {
            deck.Draw();
        }
        var lastCard = deck.Draw();

        // Assert
        Assert.Null(lastCard);
        Assert.Equal(0, deck.Count);
    }

    [Fact]
    public void Deck_Shuffle_ShouldNotChangeCardCount()
    {
        // Arrange
        var deck = new Deck(1);
        int initialCount = deck.Count;

        // Act
        deck.Shuffle();

        // Assert
        Assert.Equal(initialCount, deck.Count);
    }
}
