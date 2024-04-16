// See https://aka.ms/new-console-template for more information
using PokerFramework;

namespace PokerShuffle;

class Program
{
    static void Main()
    {
        int playerCount = 3;
        Game game = new Game(playerCount);
        game.Play();
    }
}