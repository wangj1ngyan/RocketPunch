namespace CardFramework;

public class Deck<T> where T : Card
{
    private List<T> _cards = new List<T>();
    private Random _random = new Random();
    
    protected void AddCard(T card)
    {
        _cards.Add(card);
    }
    
    // 洗牌
    public void Shuffle()
    {
        var n = _cards.Count;
        for(var i = n - 1; i > 0; i--)
        {
            var p = _random.Next(i + 1);
            (_cards[p], _cards[i]) = (_cards[i], _cards[p]);
        }
    }
    
    // 计数
    public int Count => _cards.Count;
    
    // 发牌
    public T? Deal() // ?表示可空的Card类型
    {
        if (_cards.Count > 0)
        {
            var dealtCard = _cards[^1];
            _cards.RemoveAt(_cards.Count - 1);
            return dealtCard;
        }
        else
        {
            return null; // 牌发完了
        }
    }
}