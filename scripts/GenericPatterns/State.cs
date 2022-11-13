/* State.cs
 * Generic Pattern for a State for use within a finite state machine
 * Coupled with FiniteStateMachine.cs
 * Code mostly pulled from previous project at:
 * https://github.com/mdagostino00/COP3003-Integration-Project/blob/master/Assets/Scripts/Patterns/State.cs
 */

namespace GuessMyCard.GenericPatterns
{
    internal class State<T>
    {
        protected FiniteStateMachine<T> m_fsm;

        // name of state
        public string Name { get; set; }
        // ID of state
        public T ID { get; private set; }

        /// <summary>
        /// <c>State</c>Default constructor for State
        /// </summary>
        public State()
        {
            //Debug.Log("I think something went wrong in the parameterless State() constructor.");
        }

        /// <summary>
        /// <c>State</c>constructor for state that takes a FiniteStateMachine object
        /// </summary>
        /// <param name="fsm">the FiniteStateMachine object</param>
        public State(FiniteStateMachine<T> fsm)
        {
            m_fsm = fsm;
        }

        /// <summary>
        /// <c>State</c>constructor that takes the id of the state
        /// </summary>
        /// <param name="id">the id</param>
        public State(T id)
        {
            ID = id;
        }

        /// <summary>
        /// <c>State</c>constructor that takes the id and name of a state
        /// </summary>
        /// <param name="id">the id number of the state</param>
        /// <param name="name">the name of the state</param>
        public State(T id, string name) : this(id)
        {
            Name = name;
        }

        // delegates are basically C# function pointers
        // a delegate is a reference type variable that holds the reference to a method.
        public delegate void DelegateNoArg();

        public DelegateNoArg? OnEnter;
        public DelegateNoArg? OnExit;
        public DelegateNoArg? OnUpdate;
        public DelegateNoArg? OnRender;

        /// <summary>
        /// <c>State</c>constructor that takes multiple delegate arguments for its functions
        /// </summary>
        /// <param name="id">the id</param>
        /// <param name="onEnter">onEnter function pointer</param>
        /// <param name="onExit">on Exit function pointer</param>
        /// <param name="onUpdate">onUpdate function pointer</param>
        public State(T id,
            DelegateNoArg onEnter,
            DelegateNoArg? onExit = null,
            DelegateNoArg? onUpdate = null,
            DelegateNoArg? onRender = null) : this(id)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnRender = onRender;
        }

        /// <summary>
        /// <c>State</c>constructor that takes multiple delegate arguments for its functions
        /// </summary>
        /// <param name="id">the id</param>
        /// <param name="name">the name of the state</param>
        /// <param name="onEnter">onEnter function pointer</param>
        /// <param name="onExit">on Exit function pointer</param>
        /// <param name="onUpdate">onUpdate function pointer</param>
        /// <param name="onRender">onRender function pointer</param>
        public State(T id,
            string name,
            DelegateNoArg? onEnter,
            DelegateNoArg? onExit = null,
            DelegateNoArg? onUpdate = null,
            DelegateNoArg? onRender = null) : this(id, name)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnRender = onRender;
        }

        /// <summary>
        /// <c>Enter</c>The Enter function created in FiniteStateMachine
        /// </summary>
        public virtual void Enter()
        {
            OnEnter?.Invoke();
        }

        /// <summary>
        /// <c>Exit</c>The Exit function created in FiniteStateMachine
        /// </summary>
        public virtual void Exit()
        {
            OnExit?.Invoke();
        }

        /// <summary>
        /// <c>Update</c>Unity's update function
        /// </summary>
        public virtual void Update()
        {
            OnUpdate?.Invoke();
        }

        public virtual void Render()
        {
            OnRender?.Invoke();
        }
    }
}
