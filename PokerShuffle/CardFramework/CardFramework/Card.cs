namespace CardFramework;

public abstract class Card
{
    public abstract override string ToString();
    
    public bool IsFaceUp { get; set; }
}