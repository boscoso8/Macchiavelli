namespace Macchiavelli.Tests;

public class PlayerTests
{
    [Fact]
    public void Player_ShouldBeCreatedWithName()
    {
        // Arrange & Act
        var player = new Player("John");

        // Assert
        Assert.Equal("John", player.Name);
        Assert.Empty(player.Hand);
    }

    [Fact]
    public void Player_AddCard_ShouldIncreaseHandSize()
    {
        // Arrange
        var player = new Player("Alice");
        var card = new Card(Suit.Hearts, Rank.Ace);

        // Act
        player.AddCard(card);

        // Assert
        Assert.Single(player.Hand);
        Assert.Contains(card, player.Hand);
    }

    [Fact]
    public void Player_RemoveCard_ShouldDecreaseHandSize()
    {
        // Arrange
        var player = new Player("Bob");
        var card = new Card(Suit.Spades, Rank.King);
        player.AddCard(card);

        // Act
        player.RemoveCard(card);

        // Assert
        Assert.Empty(player.Hand);
    }

    [Fact]
    public void Player_SortHand_ShouldOrderCardsBySuitAndRank()
    {
        // Arrange
        var player = new Player("Charlie");
        player.AddCard(new Card(Suit.Spades, Rank.Five));
        player.AddCard(new Card(Suit.Hearts, Rank.Three));
        player.AddCard(new Card(Suit.Hearts, Rank.Ace));

        // Act
        player.SortHand();

        // Assert
        Assert.Equal(Suit.Hearts, player.Hand[0].Suit);
        Assert.Equal(Rank.Ace, player.Hand[0].Rank);
        Assert.Equal(Suit.Hearts, player.Hand[1].Suit);
        Assert.Equal(Rank.Three, player.Hand[1].Rank);
        Assert.Equal(Suit.Spades, player.Hand[2].Suit);
    }
}
