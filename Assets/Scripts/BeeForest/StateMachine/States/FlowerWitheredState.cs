using UnityEngine;

namespace Flowers.State
{
    public class FlowerWitheredState : IState
    {
        /// <summary>
        /// This is the initial state of the flower.
        /// This State switches from a colorful flower material to a dark gray to simulate the withered flower.
        /// </summary>

        #region Variables

        private FlowerStateMachine _flowerSM;
        private Renderer _renderer;
        private Material _witheredMaterial;

        #endregion

        #region Functions

        // Specific components can be sent down from the State Machine Controller to the States.
        public FlowerWitheredState(FlowerStateMachine flowerSM, Renderer renderer, Material witheredMaterial)
        {
            _flowerSM = flowerSM;
            _renderer = renderer;
            _witheredMaterial = witheredMaterial;
        }

        // This functions marks the start of a new State and is automatically called by the State Machine.
        public void Enter()
        {
            // Switches out materials on State Change.
            Renderer copyOfRenderer = _renderer;
            Material[] copiedMaterials = copyOfRenderer.materials;
            copiedMaterials[0] = _witheredMaterial;
            copyOfRenderer.materials = copiedMaterials;
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

