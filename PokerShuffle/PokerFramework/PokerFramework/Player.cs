namespace PokerFramework;
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
        _hand.SetSortStrategy(cards => 
            cards.OrderByDescending(card => card is JokerCard { IsBigJoker: true })
                .ThenByDescending(card => card is JokerCard { IsBigJoker: false })
                .ThenBy(card => card is RankCard rankCard ? rankCard.CardSuit : default)
                .ThenByDescending(card => card is RankCard rankCard ? rankCard.CardRank : default)
                .ToList());
        
       _hand.HandSort(); 
    }

    public override string ToString()
    {
        return _hand.ToString();
    }
}