namespace PokerShuffle;
using PokerFramework;
using CardFramework;
using System.Linq;

public class Player
{
    private Hand<PokerCard> _hand;

    public Player()
    {
        _hand = new Hand<PokerCard>();
    }
    
    // 向玩家添加手牌
    public void AddCard(PokerCard card)
    {
        _hand.AddCard(card);
    }
    
    // 将手牌进行排序，先花色后数字
    public void HandSort()
    {
        Comparison<Card> cardComparison = (x, y) =>
        {
            if (x is JokerCard jx && y is JokerCard jy)
            {
                // 两张都是司令，正司令排前面
                return jy.IsBigJoker.CompareTo(jx.IsBigJoker);
            }
            if (x is JokerCard && !(y is JokerCard))
            {
                // 司令总是排在前面
                return -1;
            }
            if (!(x is JokerCard) && y is JokerCard)
            {
                return 1;
            }
            if (x is RankCard rx && y is RankCard ry)
            {
                // 先比较花色，再比较点数
                int suitComparison = rx.Suit.CompareTo(ry.Suit);
                if (suitComparison != 0) return suitComparison;
                return ry.Rank.CompareTo(rx.Rank);
            }
            return 0;
        };

        _hand.Sort(cardComparison);
    }

    public override string ToString()
    {
        return _hand.ToString();
    }
}