/* Program.cs
 * Main function for the GuessMyCard assignment
 */


using System.Xml.Linq;

namespace GuessMyCard
{
    internal class Program
    {
        public static Game? _game;

        static void Main(string[] args)
        {
            RunGame();
        }

        private static void RunGame()
        {
            _game = new Game();
            _game.Init();
            _game.RunGame();
        }
    }
}