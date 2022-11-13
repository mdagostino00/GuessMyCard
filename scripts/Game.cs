/* Game.cs
 * All of the important game loop functions go in here
 */

using GuessMyCard.CardFSM;

namespace GuessMyCard
{
    internal partial class Game
    {
        public CardFSM.CardFSM? gameFSM = null;
        public static Card? MyCard { get; set; }
        public static Dictionary<int, Card> CardList = new Dictionary<int, Card>(); // <Suit, Value>

        public static string[] SuitList = Card.suits;
        public static string[] ValueList = Card.values;
        public static Card? PlayerCard { get; set; }
        public static int Score { get; set; }
        public static bool gameloop = true;
        public static bool firstboot = true;

        public Game()
        {
            BuildCardFSMDict();
        }

        public void Init()
        {
            CreateMyCard();
            BuildCardList();
            PrintMyCard();

            /* cool code to demonstrate Game.CardList
            PrintCardList();
            Card TestCard = new Card();
            Console.WriteLine("{1} {0}", TestCard.CardValue, TestCard.CardSuit);
            RemoveCardFromDict(TestCard);
            PrintCardList();
            Card TestCard2 = new Card();
            Console.WriteLine("{1} {0}", TestCard2.CardValue, TestCard2.CardSuit);
            RemoveCardFromDict(TestCard2);
            PrintCardList();
            Card TestCard3 = new Card();
            Console.WriteLine("{1} {0}", TestCard3.CardValue, TestCard3.CardSuit);
            RemoveCardFromDict(TestCard3);
            PrintCardList();
            */
        }

        public void RunGame()
        {
            gameFSM.SetCurrentState(CardFSMStateType.START);
            while (gameloop)
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
