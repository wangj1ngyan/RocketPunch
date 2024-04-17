namespace CardFramework;


public class Hand<T> where T : Card
{
    private List<T> _hand;

    private Func<List<T>, IEnumerable<T>>? _sortStrategy;

    public Hand()
    {
        _hand = new List<T>();
    }

    public void AddCard(T card)
    {
        _hand.Add(card);
    }

    public void RemoveCard(T card)
    {
        _hand.Remove(card);
    }

    // 设置基于 Comparison<T>的排序策略
    public void Sort(Comparison<T> comparison)
    {
        _hand.Sort(comparison);
    }
    
    public override string ToString()
    {
        return string.Join(" ", _hand.Select(card => card.ToString()));
    }
    
}