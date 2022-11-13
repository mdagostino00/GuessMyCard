/* CardFSMState.cs
 * The generic state that will be used when creating the game states. 
 * Code mostly pulled from previous project found at:
 * https://github.com/mdagostino00/COP3003-Integration-Project/blob/master/Assets/Scripts/Characters/Player/Player.cs
 */

using GuessMyCard.GenericPatterns;

namespace GuessMyCard.CardFSM
{
    internal class CardFSMState : GenericPatterns.State<int>
    {
        public new CardFSMStateType ID { get { return _id; } }
        protected Game _game = null;
        protected CardFSMStateType _id;

        public CardFSMState(Game game) : base()
        {
            _game = game;
            m_fsm = _game.gameFSM;
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
    }
}
