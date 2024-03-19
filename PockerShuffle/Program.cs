using System;
using System.Collections.Generic;
using System.Linq;

// honor code: https://codereview.stackexchange.com/questions/223593/deck-of-cards-with-shuffle-and-sort-functionality

public class Card
{
    public string Suit // 花色
    { 
        get; 
        private set;
    } 
    public string Value // 数字
    {
        get; 
        private set;
    } 

    public Card(string suit, string value)
    {
        Suit = suit;
        Value = value;
    }
}

public class Initialization
{
    private List<Card> cards;
    private Random random = new Random();

    public Initialization()
    {
        cards = new List<Card>();

        // 初始化一副扑克牌4*13+2司令
        string[] suits = { "S", "H", "D", "C" }; // Spade, Heart, Diamond, Club
        string[] values = { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" }; // T 表示10
        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                cards.Add(new Card(suit, value));
            }
        }

        // 添加司令
        cards.Add(new Card("BJ", ""));
        cards.Add(new Card("LJ", ""));
    }

    // 洗牌
    // honor code： https://blog.csdn.net/weixin_30695195/article/details/96093691?utm_medium=distribute.pc_relevant.none-task-blog-2~default~baidujs_baidulandingword~default-8-96093691-blog-118154726.235^v43^pc_blog_bottom_relevance_base1&spm=1001.2101.3001.4242.5&utm_relevant_index=9
    public void Shuffle() 
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int p = random.Next(n + 1); 
            Card temp = cards[p];
            cards[p] = cards[n];
            cards[n] = temp;
        }
    }

    // 发牌
    public Card Deal()
    {
        if (cards.Count > 0)
        {
            Card dealtCard = cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }
        else
        {
            return null; // 牌发完了
        }
    }
}

public class Player
{
    private List<Card> handCard; // 用于存储每个玩家的手牌

    public Player()
    {
        handCard = new List<Card>();
    }

    // 向玩家添加手牌
    public void AddCard(Card card) 
    {
        handCard.Add(card);
    }

    // 将手牌进行排序，先花色后数字
    public void SortHand()
    {
        var sortedHand = handCard.OrderByDescending(card => card.Suit == "BJ" || card.Suit == "LJ")
                             .ThenByDescending(card => card.Suit)
                             .ThenByDescending(card => "AKQJT98765432".IndexOf(card.Value));
        handCard = sortedHand.ToList();
    }

    public string DisplayCards()
    {
        string handString = "";
        foreach (Card card in handCard)
        {
            handString += card.Suit + card.Value + " ";
        }
        return handString;
    }
}

public class Game
{
    private Initialization init;
    private List<Player> players;

    public Game()
    {
        init = new Initialization();
        players = new List<Player> { new Player(), new Player(), new Player() }; // 创建三个玩家
    }

    public void Play()
    {
        init.Shuffle();

        // 发牌
        for (int i = 0; i < 54; i++)
        {
            players[i % 3].AddCard(init.Deal());
        }

        // 排序并打印每个玩家的手牌
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SortHand();
            Console.WriteLine($"{i + 1}P: {players[i].DisplayCards()}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Play();
    }
}
