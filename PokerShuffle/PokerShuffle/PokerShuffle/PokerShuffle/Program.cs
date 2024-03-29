// See https://aka.ms/new-console-template for more information
using PokerFramework;

namespace PokerShuffle;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Play();
    }
}