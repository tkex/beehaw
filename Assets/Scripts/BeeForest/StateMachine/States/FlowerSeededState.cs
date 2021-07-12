using UnityEngine;

namespace Flowers.State
{
    public class FlowerSeededState : IState
    {
        /// <summary>
        /// This State has no visible differences to its previous one and can be expanded on later
        /// (e.g. to play Sounds instead of visual cues).
        /// </summary>

        #region Variables

        FlowerStateMachine _flowerSM;

        #endregion

        #region Functions

        // Specific components can be sent down from the State Machine Controller to the States.
        public FlowerSeededState(FlowerStateMachine flowerSM, Material petalMat)
        {
            _flowerSM = flowerSM;
        }

        // This functions marks the start of a new State and is automatically called by the State Machine.
        public void Enter()
        {

        }

        // This functions marks the end of the current State and is automatically called by the State Machine.
        public void Exit()
        {

        }
        // Allows simulation of FixedUpdate() method without a MonoBehaviour attached.
        public void FixedTick()
        {

        }
        
        // Allows simulation of Update() method without a MonoBehaviour attached.
        public void Tick()
        {

        }


        #endregion
    }
}
