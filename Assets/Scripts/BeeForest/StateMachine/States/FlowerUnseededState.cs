using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this state we just want to wait for a length of time, then transition back to idle
/// Because IState is not inheriting from MonoBehaviour, we don't have access to Coroutines
/// This means that we're going to have to implement our own simple timer system.
/// </summary>

namespace Flowers.State
{
    public class FlowerUnseededState : IState
    {
        /// <summary>
        /// This State disables the withered flower and enables a dug out hole with a dirt pile in its position instead.
        /// </summary>

        #region Variables

        FlowerStateMachine _flowerSM;

        #endregion

        #region Functions

        // Specific components can be sent down from the State Machine Controller to the States.
        public FlowerUnseededState(FlowerStateMachine flowerSM)
        {
            _flowerSM = flowerSM;
        }

        // This functions marks the start of a new State and is automatically called by the State Machine.
        public void Enter()
        {
            // Disables flower object and enables dirt pile / dug out hole.
            _flowerSM.ToggleGameObjects("DugOutHole", true);
            _flowerSM.ToggleGameObjects("FlowerBody", false);
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

