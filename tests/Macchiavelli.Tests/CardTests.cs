namespace Macchiavelli.Tests;

public class CardTests
{
    [Fact]
    public void Card_ShouldHaveCorrectSuitAndRank()
    {
        // Arrange & Act
        var card = new Card(Suit.Hearts, Rank.Ace);

        // Assert
        Assert.Equal(Suit.Hearts, card.Suit);
        Assert.Equal(Rank.Ace, card.Rank);
    }

    [Fact]
    public void Card_ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        var card = new Card(Suit.Hearts, Rank.Ace);

        // Act
        var result = card.ToString();

        // Assert
        Assert.Equal("A♥", result);
    }

    [Theory]
    [InlineData(Suit.Hearts, "Red")]
    [InlineData(Suit.Diamonds, "Red")]
    [InlineData(Suit.Clubs, "Black")]
    [InlineData(Suit.Spades, "Black")]
    public void Card_GetColor_ShouldReturnCorrectColor(Suit suit, string expectedColor)
    {
        // Arrange
        var card = new Card(suit, Rank.Five);

        // Act
        var color = card.GetColor();

        // Assert
        Assert.Equal(expectedColor, color);
    }

    [Fact]
    public void Card_FaceCards_ShouldHaveCorrectStringRepresentation()
    {
        // Arrange & Act
        var jack = new Card(Suit.Spades, Rank.Jack);
        var queen = new Card(Suit.Diamonds, Rank.Queen);
        var king = new Card(Suit.Clubs, Rank.King);

        // Assert
        Assert.Equal("J♠", jack.ToString());
        Assert.Equal("Q♦", queen.ToString());
        Assert.Equal("K♣", king.ToString());
    }
}
