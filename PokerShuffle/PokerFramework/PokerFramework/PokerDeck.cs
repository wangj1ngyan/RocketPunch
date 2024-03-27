namespace PokerFramework;
using CardFramework;

public class PokerDeck : Deck<PokerCard>
{
    
    public PokerDeck()
    {
        // 添加52张普通牌
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                AddCard(new RankCard(suit, rank));
            }
        }

        // 添加大小王
        AddCard(new JokerCard(true));
        AddCard(new JokerCard(false));
    }

}
