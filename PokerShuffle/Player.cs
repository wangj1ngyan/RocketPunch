using System;
using System.Collections.Generic;

public class Player
{
    private List<Card> _hand; // 用于存储每个玩家的手牌

    public Player()
    {
        _hand = new List<Card>();
    }

    // 向玩家添加手牌
    public void AddCard(Card card)
    {
        _hand.Add(card);
    }

    // 将手牌进行排序，先花色后数字
    public void SortHand()
    {
        _hand = _hand.OrderByDescending(card => card is JokerCard)
                     .ThenByDescending(card => card is RankCard rankCard ? rankCard.CardSuit : default)
                     .ThenByDescending(card => card is RankCard rankCard ? rankCard.CardRank : default)
                     .ToList();
    }

    public override string ToString()
    {
        return string.Join(" ", _hand.Select(_card => _card.ToString()));
    }
}