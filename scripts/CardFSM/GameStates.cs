/* GameStates.cs
 * Contains all states for the GuessMyCard game
 */

namespace GuessMyCard.CardFSM
{
    public enum CardFSMStateType
    {
        START,
        WIN,
        QUIT,
        LOWER,
        HIGHER,
    }


    internal class CardFSMState_START : CardFSMState
    {
        public CardFSMState_START(Game game) : base(game)
        {
            _id = CardFSMStateType.START;
        }
        public override void Enter()
        {
            if (Game.firstboot)
            {
                Console.WriteLine("Welcome to the Guess My Card Game!");
                Console.WriteLine("Your computer has chosen a random card out of a deck of 52 cards (jokers excluded).");
                Console.WriteLine("You need to guess what the card is in the fewest guesses possible!");
                Console.WriteLine("You will have to guess a suit and a value.");
                Console.WriteLine("When you guess the correct suit or value, you will be told that one of your options is correct!");
                Console.WriteLine("Good Luck! Aim for the lowest score!");
                Console.WriteLine("(If you want to quit the game, enter \"quit\" at any time.)\n");
                Game.firstboot = false;
            }
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void Update()
        {
            // first, we get the player's input for the suit
            Console.WriteLine("Valid Suits: ");
            foreach(var suit in Game.SuitList)
            {
                Console.WriteLine("|{0} ", suit);
            }
            Console.Write("Enter your desired suit: ");
            string? yourSuit = _game.GetPlayerInput();
            if (yourSuit == null) // if the player wants to quit
            {
                return; // stop processing Update()
            }

            // next, we get the player's input for the values
            Console.WriteLine("Valid Values: ");
            foreach(var value in Game.ValueList)
            {
                Console.WriteLine("|{0}", value);
            }
            Console.Write("Enter your desired value: ");
            string? yourValue = _game.GetPlayerInput();
            if (yourSuit == null) // also if the player wants to quit
            {
                return; // stop processing Update()
            }

            // last, if the player hasn't decided to quit the game yet, create a card out of their inputs
            if (_game.gameFSM.GetCurrentState() == _game.gameFSM.GetState(CardFSMStateType.START))
            {
                if (!Card.suits.Contains(yourSuit) || !Card.values.Contains(yourValue))
                {
                    Console.WriteLine("Your selected card of {0} and {1} is not a valid card!", yourSuit, yourValue);
                    Console.WriteLine("Make another card! (or enter \"quit\" to exit the app)");
                }
                else
                {
                    Game.PlayerCard = new Card(yourSuit, yourValue);
                    Console.WriteLine("Your chosen card is the {1} of {0}!", Game.PlayerCard.CardSuit, Game.PlayerCard.CardValue);
                }
            }
        }
        public override void Render()
        {
            // if we don't have a card, probably because we chose to quit in the first round, then perish
            if (Game.PlayerCard == null)
            {
                return;
            }
            
            // check if player's suit matches the game's suit
            if (Game.PlayerCard.CardSuit == Game.MyCard.CardSuit)
            {
                Console.WriteLine("You chose the same suit as my card's suit!");
            }
            else
            {
                Console.WriteLine("Your suit is incorrect.");
            }

            // get the index of the card values, with 2 being the lowest index and ace being the highest index
            int yourCardValueIndex = Array.IndexOf(Card.values, Game.PlayerCard.CardValue);
            int myCardValueIndex = Array.IndexOf(Card.values, Game.MyCard.CardValue);
            if (yourCardValueIndex == -1)
            {
                Console.Error.WriteLine("Somehow, every check to see if you had a legit card in the CardFSMState_START.Render() function has failed!");
                return;
            }
            if (yourCardValueIndex > myCardValueIndex)
            {
                _game.gameFSM.SetCurrentState(CardFSMStateType.HIGHER);
            }
            else if (yourCardValueIndex < myCardValueIndex)
            {
                _game.gameFSM.SetCurrentState(CardFSMStateType.LOWER);
            }
            else if (yourCardValueIndex == myCardValueIndex)
            {
                if (Game.PlayerCard.CardSuit == Game.MyCard.CardSuit)
                {
                    _game.gameFSM.SetCurrentState(CardFSMStateType.WIN);
                }
                Console.WriteLine("Your card's value is the same as my card's value!");
            }
        }
    }


    internal class CardFSMState_WIN : CardFSMState
    {
        public CardFSMState_WIN(Game game) : base(game)
        {
            _id = CardFSMStateType.WIN;
        }
        public override void Enter()
        {
            base.Enter();
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Render()
        {
            base.Render();
        }
    }


    internal class CardFSMState_QUIT : CardFSMState
    {
        public CardFSMState_QUIT(Game game) : base(game)
        {
            _id = CardFSMStateType.QUIT;
        }
        public override void Enter()
        {
            base.Enter();
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void Update()
        {
            Console.Write("Would you like to quit the game? [y/n] ");
            string? option = Console.ReadLine();
            if (string.IsNullOrEmpty(option) || option == "y")
            {
                Game.gameloop = false;
            }
            else
            {
                _game.gameFSM.SetCurrentState(CardFSMStateType.START);
            }
        }
        public override void Render()
        {
            if (Game.gameloop == false) {
                Console.WriteLine("Thank you for playing!");
            }
        }
    }


    internal class CardFSMState_LOWER : CardFSMState
    {
        public CardFSMState_LOWER(Game game) : base(game)
        {
            _id = CardFSMStateType.LOWER;
        }
        public override void Enter()
        {
            Console.WriteLine("Your card's value is lower than my card!");
        }
        public override void Exit()
        {
            Console.WriteLine("You have made a total of {0} guesses!", Game.Score);
            Console.WriteLine("If you want to give up, just type \"quit\"!\n");
        }
        public override void Update()
        {
            Game.Score++;
        }
        public override void Render()
        {
            _game.gameFSM.SetCurrentState(CardFSMStateType.START);
        }
    }


    internal class CardFSMState_HIGHER : CardFSMState
    {
        public CardFSMState_HIGHER(Game game) : base(game)
        {
            _id = CardFSMStateType.HIGHER;
        }
        public override void Enter()
        {
            Console.WriteLine("Your card's value is lower than my card!");
        }
        public override void Exit()
        {
            Console.WriteLine("You have made a total of {0} guesses!", Game.Score);
            Console.WriteLine("If you want to give up, just type \"quit\"!\n");
        }
        public override void Update()
        {
            Game.Score++;
        }
        public override void Render()
        {
            _game.gameFSM.SetCurrentState(CardFSMStateType.START);
        }
    }
}
