using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWinningManager : MonoBehaviour
{
    /// <summary>
    /// File that contains the winning logic of the scene (WinningManager)
    /// </summary>


    #region Variables

    // Set here GameObject of socket parent (in this case 'SocketInteraction')
    // that have several socket child-gameobjects with each an attached SocketEvent script.
    [Header("Socket Settings")]
    [Tooltip("Set the SocketInteraction gameobject (parent).")]
    [SerializeField] private GameObject _socketGo;


    [Header("Particle Settings")]
    [Tooltip("Set the particle GameObject when winning the game.")]
    [SerializeField] private GameObject _particleGo;
    [Tooltip("Set the shining GameObject position when winning the game.")]
    [SerializeField] private Vector3 _particlePosition = new Vector3(-0.2f, 1.0f, 1.8f);

    [Header("Shine Settings")]
    [Tooltip("Set the shining GameObject when winning the game.")]
    [SerializeField] private GameObject _shiningGo;
    [SerializeField] private Vector3 _shiningPosition = new Vector3(0.4f, -0.5f, 1.6f);
    
    [Header("Audio Settings")]
    [Tooltip("Set audio clip that will be played when winning the game.")]
    [SerializeField] private AudioClip myWinningSound;

    private int _amountOfActiveBees;
    private int _amountOfChildrenBees;

    private bool _areAllBeesActive;

    #endregion

    
    // Singleton.
    #region Singleton

    // Declare Particle Manager Singleton instance.
    public static BeeWinningManager Instance;

    // Initialize the singleton instance when script instance is being loaded.
    private void Awake()
    {
        // Set instance of ParticleManager to this.
        Instance = this;
    }

    #endregion


    #region Functions    

    void Start() {
        CountActiveChildrenBees();
    }

    void Update() {
        checkActivatedBees();
        WinningCheck();
    }

    // Function to call when sockets are filled completely.
    public void WinningRoutine()
    {
        // Show Light
        Instantiate(_shiningGo, _shiningPosition, Quaternion.identity);

        // Spawn Particle        
        ParticleManager.Instance.SpawnParticle(_particleGo, _particlePosition, Quaternion.identity);

        // Play winning Sound
        AudioManager.Instance.PlayWinningSound(myWinningSound);

        // Countdown from 10 Sec to quit scene back to lobby.
        ExitGame.Instance.ExitScene();
    }

    // Function for counting all bee children of a parent bee GameObject.
    public int CountActiveChildrenBees() {

        foreach (Transform child in _socketGo.transform)
        {
            // Increase the value by one for each found child game object in a socket parent.
            _amountOfChildrenBees += 1;
            //Debug.Log(_amountOfChilds);
        }    
            
        return _amountOfChildrenBees;
    }

    private int checkActivatedBees() 
    {
         foreach (Transform child in _socketGo.transform)
            {
                if (child.GetComponent<MoveBee>().enabled == true)
                {
                    // Increase value by one if child has _enteredSocket set as true.
                    _amountOfActiveBees += 1;
                }

                // Debug.Log(_amountOfEnteredSockets);
            }

        return _amountOfActiveBees;
    }

    private void WinningCheck() {

        // Check if all bees are already active.
        if(!_areAllBeesActive)
        {
            Debug.Log("WORKS TIL HERE.");
            // Check if before counted child elements are equal to the
            // amount of gameobjects that have the MoveBee script enabled.
            if (_amountOfChildrenBees == _amountOfActiveBees)
            {
              
                _areAllBeesActive = true;

                // Call winning function.
                WinningRoutine();
                //Debug.Log("WINNING ROUTINE WORKS");
            }
            else
            {
                // Reset the amount of bees to null so old values
                // don't get added up in the update function.
                _amountOfActiveBees = 0;
            }
         }       

    }

    #endregion
}
