/* Program.cs
 * Main function for the GuessMyCard assignment
 */


using System.Xml.Linq;

namespace GuessMyCard
{
    internal class Program
    {
        public static Card? _myCard { get; set; }
        public static Dictionary<int, string[]> CardList = new Dictionary<int, string[]>(); // <Suit, Value>
        public static Game game = new Game();

        static void Main(string[] args)
        {
            Init();

        }

        private static void Init()
        {
            CreateMyCard();
            BuildCardList();
            PrintCardList();
            PrintMyCard();
        }

        private static void CreateMyCard()
        {
            Card myCard = new Card();
            _myCard = myCard;
        }

        private static void PrintMyCard()
        {
            Console.WriteLine("My Card is the {0} of {1}!", _myCard.CardValue, _myCard.CardSuit);
        }

        private static void BuildCardList()
        {
            int index = 0;
            foreach (string suit in Card.suits)
            {
                foreach (string value in Card.values)
                {
                    string[] card = {suit, value};
                    CardList.Add(++index, card);
                }
            }
        }

        private static void PrintCardList()
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}, {2}", CardList.ElementAt(i).Key, CardList.ElementAt(i).Value[0], CardList.ElementAt(i).Value[1]);
            }
        }
    }
}