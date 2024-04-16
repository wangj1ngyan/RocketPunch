using CardFramework;

namespace PokerFramework;

public class PokerHand : Hand<Card>
{

    // 特定于扑克牌的添加牌操作
    public new void AddCard(Card card)
    {
        base.AddCard(card);
    }

    // 特定于扑克牌的移除牌操作
    public new void RemoveCard(Card card)
    {
        base.RemoveCard(card);
    }

    // 特定于扑克牌的默认排序策略
    public void DefaultSort()
    {
        Comparison<Card> pokerComparison = (x, y) =>
        {
            bool xIsJoker = x is JokerCard;
            bool yIsJoker = y is JokerCard;
                
            if (xIsJoker && yIsJoker)
            {
                // 两张都是司令，正司令排前面
                return ((JokerCard)y).IsBigJoker.CompareTo(((JokerCard)x).IsBigJoker);
            }
            if (xIsJoker) return -1; // 司令总是排在前面
            if (yIsJoker) return 1;

            var rx = x as RankCard;
            var ry = y as RankCard;
            if (rx != null && ry != null)
            {
                // 先比较花色，再比较点数
                int suitComparison = rx.CardSuit.CompareTo(ry.CardSuit);
                if (suitComparison != 0) return suitComparison;
                return ry.CardRank.CompareTo(rx.CardRank);
            }
            return 0;
        };

        Sort(pokerComparison);
    }
}