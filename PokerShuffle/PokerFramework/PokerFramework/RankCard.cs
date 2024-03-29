namespace PokerFramework;
using CardFramework;

public class RankCard : PokerCard
{
    public Suit CardSuit { get; init;  }
    
    public Rank CardRank { get; init;  }
    
    public RankCard(Suit suit, Rank rank)
    {
        CardSuit = suit;
        CardRank = rank;
    }

    public override string ToString()
    {
        var suitStr = CardSuit switch
        {
            Suit.Spade => "S",
            Suit.Heart => "H",
            Suit.Diamond => "D",
            Suit.Club => "C",
            _ => throw new InvalidOperationException("Invalid suit")
        };

        var rankStr = CardRank switch
        {
            Rank.Two => "2",
            Rank.Three => "3",
            Rank.Four => "4",
            Rank.Five => "5",
            Rank.Six => "6",
            Rank.Seven => "7",
            Rank.Eight => "8",
            Rank.Nine => "9",
            Rank.Ten => "T",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            Rank.Ace => "A",
            _ => throw new InvalidOperationException("Invalid rank")
        };

        return $"{suitStr}{rankStr}";
    }
}