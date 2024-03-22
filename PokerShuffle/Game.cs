using System.Collections.Generic;
using System;

public class Game
{
    private Deck _deck;
    private List<Player> _players;

    public Game()
    {
        _deck = new Deck();
        _players = new List<Player> { new Player(), new Player(), new Player() };
    }

    public void Play()
    {
        _deck.Shuffle();

        while (_deck.Count > 0)
        {
            foreach (var player in _players)
            {
                Card? card = _deck.Deal();
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
            player.SortHand();
            Console.WriteLine(player);
        }
    }
}
