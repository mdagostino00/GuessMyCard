

namespace GuessMyCard
{
    internal class Game
    {
        public CardFSM.CardFSM? gameFSM = null;

        public Game()
        {
            BuildCardFSMDict();
        }


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
    }
}
