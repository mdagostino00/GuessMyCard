/* Game.cs
 * All of the important game loop functions go in here
 */

using GuessMyCard.CardFSM;

namespace GuessMyCard
{
    internal partial class Game
    {
        public CardFSM.CardFSM? gameFSM = null;
        public static Card? _myCard { get; set; }
        public static Dictionary<int, Card> CardList = new Dictionary<int, Card>(); // <Suit, Value>

        public static string[] SuitList = Card.suits;
        public static string[] ValueList = Card.values;
        public static Card? _guessedCard { get; set; }
        public static int _score { get; set; }
        public static bool _gameloop = true;
        public static bool _firstboot = true;

        public Game()
        {
            BuildCardFSMDict();
        }

        public void Init()
        {
            CreateMyCard();
            BuildCardList();
            PrintCardList();
            PrintMyCard();
        }

        public void RunGame()
        {
            gameFSM.SetCurrentState(CardFSMStateType.START);
            while (_gameloop)
            {
                gameFSM.Update();
                gameFSM.Render();
            }
        }

        public void QuitGame()
        {
            Console.Write("Would you like to quit the game? [y/n] ");
            string? option = Console.ReadLine();
        }
    }
}
