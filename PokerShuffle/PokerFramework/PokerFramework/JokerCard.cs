namespace PokerFramework;
using CardFramework;

public class JokerCard : PokerCard
{
    public bool IsBigJoker { get; init; }

    public JokerCard(bool isBigJoker)
    {
        IsBigJoker = isBigJoker;
    }

    public override string ToString()
    {
        return IsBigJoker ? "BJ" : "LJ";
    }
}