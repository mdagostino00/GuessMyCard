/* FSMFacade.cs
 * Provides better access to the generic FiniteStateMachine template class
 * Code mostly pulled from previous project found at:
 * https://github.com/mdagostino00/COP3003-Integration-Project/blob/master/Assets/Scripts/Characters/Player/Player.cs
 */

using GuessMyCard.GenericPatterns;

namespace GuessMyCard.CardFSM
{
    internal class CardFSM : GenericPatterns.FiniteStateMachine<int>
    {
        /// <summary>
        /// <c>CardFSM</c>
        /// calls the base constructor, which makes a dictionary of ints
        /// </summary>
        public CardFSM() : base() { }

        /// <summary>
        /// <c>Add</c>adds the state to the dictionary of states found in the base class FiniteStateMachine
        /// </summary>
        /// <param name="state">the state we want to add</param>
        public void Add(CardFSMState state)
        {
            m_states.Add((int)state.ID, state);
        }

        /// <summary>
        /// <c>GetState</c>Returns the state when given a key in the CardFSMStateType enum.
        /// </summary>
        /// <param name="key">the state listed in the <see cref="CardFSMStateType"/></param>
        /// <returns>The state casted to CardFSMState</returns>
        public CardFSMState GetState(CardFSMStateType key)
        {
            return (CardFSMState)GetState((int)key);
        }

        /// <summary>
        /// <c>SetCurrentState</c>sets the current state in the PlayerFSM to the desired state in the <see cref="PlayerFSMStateType"/>
        /// </summary>
        /// <param name="stateKey">the key in the <see cref="PlayerFSMStateType"/></param>
        public void SetCurrentState(CardFSMStateType stateKey)
        {
            State<int> state = m_states[(int)stateKey];
            if (state != null)
            {
                SetCurrentState(state);
            }
        }
    }
}
