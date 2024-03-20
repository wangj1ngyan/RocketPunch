using System;
using System.Collections.Generic;

public class Card
{
    public enum Suit
    {
        Spade,
        Heart,
        Diamond, 
        Club,
        Joker
    }

    public enum Rank
    {
        Two = 2, 
        Three, 
        Four, 
        Five, 
        Six, 
        Seven, 
        Eight, 
        Nine, 
        Ten, 
        Jack, 
        Queen, 
        King, 
        Ace
    }

    public Suit CardSuit { get; init; }
    public Rank CardRank { get; init; }
    public bool IsJoker { get; init; }


    public Card(Suit _suit, Rank _rank, bool _isJoker = false)
    {
        CardSuit = _suit;
        CardRank = _rank;
        IsJoker = _isJoker;
    }

    // 转换枚举到字符串表示
    public override string ToString()
    {
        if (IsJoker)
        {
            return CardSuit == Suit.Joker ? "BJ" : "LJ";
        }
        string rank = CardRank switch
        {
            Rank.Ten => "T",
            Rank.Jack => "J",
            Rank.Queen => "Q",
            Rank.King => "K",
            Rank.Ace => "A",
            _ => ((int)CardRank).ToString(),
        };
        string suit = CardSuit switch
        {
            Suit.Spade => "S",
            Suit.Heart => "H",
            Suit.Diamond => "D",
            Suit.Club => "C",
            _ => throw new InvalidOperationException("Invalid suit"),
        };
        return $"{suit}{rank}";
    }
}
