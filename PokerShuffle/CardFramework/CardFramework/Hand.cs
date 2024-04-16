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

    // 设置基于 Cumparison<T>的排序策略
    public void Sort(Comparison<T> comparison)
    {
        _hand.Sort(comparison);
    }
    // 设置基于 Func 的排序策略
    public void SetSortStrategy(Func<List<T>, IEnumerable<T>> sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }
    
    // 如果使用排序策略，传入排序策略
    public void HandSort()
    {
        if (_sortStrategy != null)
        {
            _hand = _sortStrategy(_hand).ToList();
        }
    }
    
    public override string ToString()
    {
        return string.Join(" ", _hand.Select(card => card.ToString()));
    }
    
}