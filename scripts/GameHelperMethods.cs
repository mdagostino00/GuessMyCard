﻿/* GameLoop.cs
 * all of the functions needed to initialize the basic game loop go in here
 */

using GuessMyCard.CardFSM;
using System.Xml.Linq;

namespace GuessMyCard
{
    internal partial class Game
    {
        private void BuildCardFSMDict()
        {
            // First, create a new instance of a FiniteStateMachine
            gameFSM = new CardFSM.CardFSM();

            // Next, add all of the created states into the dictionary of states
            gameFSM.Add(new CardFSM.CardFSMState_START(this));
            gameFSM.Add(new CardFSM.CardFSMState_WIN(this));
            gameFSM.Add(new CardFSM.CardFSMState_QUIT(this));
            gameFSM.Add(new CardFSM.CardFSMState_LOWER(this));
            gameFSM.Add(new CardFSM.CardFSMState_HIGHER(this));
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
                    Card card = new Card(suit, value);
                    CardList.Add(++index, card);
                }
            }
        }

        private static void PrintCardList()
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                Console.WriteLine("Key: {0}, Value: {1}, {2}", CardList.ElementAt(i).Key, CardList.ElementAt(i).Value.CardSuit, CardList.ElementAt(i).Value.CardValue);
            }
        }

        public string GetPlayerInput()
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToLower() == "quit")
            {
                gameFSM.SetCurrentState(CardFSMStateType.QUIT);
                return null;
            }
            return input.ToLower();
        }
    }
}