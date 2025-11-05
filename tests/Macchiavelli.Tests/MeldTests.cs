namespace Macchiavelli.Tests;

public class MeldTests
{
    [Fact]
    public void Meld_ValidRun_ShouldBeValid()
    {
        // Arrange
        var meld = new Meld(MeldType.Run);
        meld.AddCard(new Card(Suit.Hearts, Rank.Three));
        meld.AddCard(new Card(Suit.Hearts, Rank.Four));
        meld.AddCard(new Card(Suit.Hearts, Rank.Five));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void Meld_ValidSet_ShouldBeValid()
    {
        // Arrange
        var meld = new Meld(MeldType.Set);
        meld.AddCard(new Card(Suit.Hearts, Rank.Seven));
        meld.AddCard(new Card(Suit.Diamonds, Rank.Seven));
        meld.AddCard(new Card(Suit.Clubs, Rank.Seven));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void Meld_RunWithOnlyTwoCards_ShouldBeInvalid()
    {
        // Arrange
        var meld = new Meld(MeldType.Run);
        meld.AddCard(new Card(Suit.Hearts, Rank.Three));
        meld.AddCard(new Card(Suit.Hearts, Rank.Four));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Meld_SetWithSameSuit_ShouldBeInvalid()
    {
        // Arrange
        var meld = new Meld(MeldType.Set);
        meld.AddCard(new Card(Suit.Hearts, Rank.Seven));
        meld.AddCard(new Card(Suit.Hearts, Rank.Seven));
        meld.AddCard(new Card(Suit.Diamonds, Rank.Seven));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Meld_RunWithDifferentSuits_ShouldBeInvalid()
    {
        // Arrange
        var meld = new Meld(MeldType.Run);
        meld.AddCard(new Card(Suit.Hearts, Rank.Three));
        meld.AddCard(new Card(Suit.Diamonds, Rank.Four));
        meld.AddCard(new Card(Suit.Hearts, Rank.Five));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Meld_RunWithNonConsecutiveRanks_ShouldBeInvalid()
    {
        // Arrange
        var meld = new Meld(MeldType.Run);
        meld.AddCard(new Card(Suit.Hearts, Rank.Three));
        meld.AddCard(new Card(Suit.Hearts, Rank.Five));
        meld.AddCard(new Card(Suit.Hearts, Rank.Seven));

        // Act
        var isValid = meld.IsValid();

        // Assert
        Assert.False(isValid);
    }
}
