namespace PokerFramework;
using CardFramework;

public class Game
{
    private int _playerCount = 3; // 用于指定玩家数
    
    private PokerDeck _deck;
    
    private List<Player> _players;

    public Game()
    {
        _deck = new PokerDeck();
        _players = new List<Player>();
        
        for (var i = 0; i < _playerCount; i++)
        {
            _players.Add(new Player());
        }
    }

    public void Play()
    {
        _deck.Shuffle();

        while (_deck.Count > 0)
        {
            foreach (var player in _players)
            {
                var card = _deck.Deal();
                if (card != null)
                {
                    player.AddCard(card);
                }
                else
                {
                    break;
                }
            }
        }

        foreach (var player in _players)
        {
            player.HandSort();
            Console.WriteLine(player);
        }
    }
}