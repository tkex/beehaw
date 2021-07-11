using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Flowers.State
{
    /// <summary>
    /// File that contains the State Machine Controller.
    /// </summary>

    /// <summary>
    /// The idea:
    /// The State Machine Controller creates and activates all of its states here. Any references that the
    /// states need can be accessed and passed down through here as well.
    /// </summary>

    public class FlowerStateMachine : StateMachineMB
    {
        #region Variables

        // Instantiates all States.
        public FlowerWitheredState WitheredState { get; private set; }
        public FlowerGrowState GrowState { get; private set; }
        public FlowerUnseededState UnseededState { get; private set; }
        public FlowerSeededState SeededState { get; private set; }

        [Header("Required References")]
        // References passed in through the Inspector can be passed down to the States.
        [Tooltip("Set the Renderer of Flower GameObject.")]
        [SerializeField] private Renderer _flowerRenderer = null;

        [Tooltip("Set Flower Material.")]
        [SerializeField] private Material _flowerMaterial;

        [Tooltip("Set withered Flower Material.")]
        [SerializeField] private Material _witheredMaterial;

        [Tooltip("Set Bee this flower will attract.")]
        [SerializeField] private GameObject _beeGo;

        // A List of all Collisions the Flower registers.
        List<GameObject> currentCollisions = new List<GameObject>();

        // Reference to the ToggleGameObject script attached to the flower.
        private ToggleGameObject _toggledGameObject => GetComponent<ToggleGameObject>();

        #endregion


        #region Functions
        private void Awake()
        {
            // Pass required data for the states through the Constructor.
            WitheredState = new FlowerWitheredState(this, _flowerRenderer, _witheredMaterial);
            GrowState = new FlowerGrowState(this, _flowerRenderer, _flowerMaterial, _beeGo);
            UnseededState = new FlowerUnseededState(this);
            SeededState = new FlowerSeededState(this, _flowerRenderer.material);
        }

        private void Start()
        {
            // Set initial State to "Withered State".
            ChangeState(WitheredState);
        }

        // Function for changing States on specific particle collisions.
        private void OnParticleCollision(GameObject gameObject)
        {
            // Change State to "Seeded State" once particle collision with seeds has occured and current State is "Unseeded".
            if (currentState == UnseededState && gameObject.name == "Particle_Seeds")
            {
                ChangeState(SeededState);
            }

            // Change State to "Grow State" once particle collision with water has occured and current State is "Seeded".
            if (currentState == SeededState && gameObject.name == "Particle_Water")
            {
                ChangeState(GrowState);
            }
        }

        // Function for adding GameObjects to the collision List.
        void OnCollisionEnter(Collision collision)
        {
            currentCollisions.Add(collision.gameObject);
        }

        // Function for changing States on specific collisions.
        void OnCollisionExit(Collision collision)
        {
            // Remove the GameObject collided with from the list.
            currentCollisions.Remove(collision.gameObject);

            foreach (GameObject go in currentCollisions)
            {
                // Change State to "Unseeded State" once Collision with Trowel has occured and current State is "Wthered".
                if (currentState == WitheredState && go.name == "Trowel")
                {
                    ChangeState(UnseededState);
                }
            }
        }

        // Function that toggles child GameObjects on/off.
        public void ToggleGameObjects(string goToToggle, bool isActive)
        {
            // Get GameObject from string.
            Transform goTransform = gameObject.transform.Find(goToToggle);

            // Call to ToggleGameObject script.
            _toggledGameObject.ToggleActive(goTransform.gameObject, isActive);
        }
    }

    #endregion
}
