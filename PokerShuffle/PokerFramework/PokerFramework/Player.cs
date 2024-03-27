namespace PokerFramework;
using CardFramework;

public class Player
{
    private List<PokerCard> _hand = new List<PokerCard>(); // 用于存储每个玩家的手牌
    
    // 向玩家添加手牌
    public void AddCard(PokerCard card)
    {
        _hand.Add(card);
    }

    // 将手牌进行排序，先花色后数字
    public void SortHand()
    {
        _hand = _hand.OrderByDescending(card => card is JokerCard { IsBigJoker: true })
            .ThenByDescending(card => card is JokerCard { IsBigJoker: false })
            .ThenBy(card => card is RankCard rankCard ? rankCard.CardSuit : default)
            .ThenByDescending(card => card is RankCard rankCard ? rankCard.CardRank : default)
            .ToList();
    }

    public override string ToString()
    {
        return string.Join(" ", _hand.Select(card => card.ToString()));
    }
}