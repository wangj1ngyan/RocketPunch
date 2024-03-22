using System.Collections.Generic;
using System;

public class Deck
{
    private List<Card> _cards;
    private Random random = new Random();

    public Deck()
    {
        _cards = new List<Card>();
        _cards.Add(new JokerCard(true)); // 正司令
        _cards.Add(new JokerCard(false)); //副司令

        // 初始化一副扑克牌4*13+2司令
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new RankCard(suit, rank)); // 添加RankCard
            }
        }
    }

    // 洗牌
    public void Shuffle()
    {
        int n = _cards.Count;
        for(int i = n-1; i>0; i--)
        {
            int p = random.Next(i + 1);
            (_cards[p], _cards[i]) = (_cards[i], _cards[p]);
        }
    }

    // 计数
    public int Count
    {
        get { return _cards.Count; }
    }

    // 发牌
    public Card? Deal() // ?表示可空的Card类型
    {
        if (_cards.Count > 0)
        {
            Card dealtCard = _cards[0];
            _cards.RemoveAt(0);
            return dealtCard;
        }
        else
        {
            return null; // 牌发完了
        }
    }
}