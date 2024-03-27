using CardFramework;

namespace PokerFramework;

public abstract class PokerCard : Card
{
    public Suit CardSuit { get; init;  }
    public Rank CardRank { get; init;  }

    public override string ToString()
    {
        return $"{CardSuit}{CardRank}";
    }
}