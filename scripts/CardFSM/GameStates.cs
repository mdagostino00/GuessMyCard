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
            base.Update();
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


    internal class CardFSMState_HIGHER : CardFSMState
    {
        public CardFSMState_HIGHER(Game game) : base(game)
        {
            _id = CardFSMStateType.HIGHER;
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
