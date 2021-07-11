using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WinningManager : MonoBehaviour
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
    [SerializeField] private Vector3 _particlePosition = new Vector3(2.7f, 1.0f, 0.6f);

    [Header("Shine Settings")]
    [Tooltip("Set the shining GameObject when winning the game.")]
    [SerializeField] private GameObject _shiningGo;
    [SerializeField] private Vector3 _shiningPosition = new Vector3(3.5f, -0.5f, 0.0f);
    
    [Header("Audio Settings")]
    [Tooltip("Set audio clip that will be played when winning the game.")]
    [SerializeField] private AudioClip myWinningSound;

    /// Variable for holding the value of socket children of a parent sockt interaction gameobject.
    private int _amountOfChilds;
    /// Variable for holding the value entered sockets in the scene.
    private int _amountOfEnteredSockets;
    // Variable for checking if all sockets are filled.
    private bool _isSocketFilledCompletely = false;

    #endregion


    #region Functions    

    private void Start()
    {
        // Call function at the start for counting all child gameobjects
        // of a assigned SocketInteraction parent gameobject.
        CountSocketInteractionChildren();       
    }

    void Update()
    {
        // Call function to check constantly if sockets are filled out.
        SocketCheck();
    }

    // Function for counting all child elements of a SocketInteraction parent.
    private void CountSocketInteractionChildren()
    {
        foreach (Transform child in _socketGo.transform)
        {
            // Increase the value by one for each found child game object in a socket parent.
            _amountOfChilds += 1;
            //Debug.Log(_amountOfChilds);
        }
    }

    // Function for checking if the available sockets are filled out.
    private void SocketCheck()
    {
        // Check if sockets are still not filled out.
        if(!_isSocketFilledCompletely)
        {
            foreach (Transform child in _socketGo.transform)
            {
                if (child.GetComponent<SocketEvents>().hasEnteredSocket == true)
                {
                    // Increase value by one if child has _enteredSocket set as true.
                    _amountOfEnteredSockets += 1;
                }

                // Debug.Log(_amountOfEnteredSockets);
            }

            // Check if before counted child elements are equal to the
            // amount of gameobjects that have the hasEnteredSocket enabled.
            if (_amountOfEnteredSockets == _amountOfChilds)
            {
              
                _isSocketFilledCompletely = true;

                // Call winning function.
                WinningRoutine();

                //Debug.Log("Socket is filled completely.");
            }
            else
            {
                // Reset the amount of entered sockets to null so old values
                // don't get added up in the update function.
                _amountOfEnteredSockets = 0;
            }
         }       
    }

    // Function to call when sockets are filled completely.
    private void WinningRoutine()
    {
        // Show Light
        Instantiate(_shiningGo, _shiningPosition, Quaternion.identity);

        // Spawn Particle        
        ParticleManager.Instance.SpawnParticle(_particleGo, _particlePosition, Quaternion.identity);

        // Play winning Sound
        AudioManager.Instance.PlayWinningSound(myWinningSound);

        // Countdown from 10 Sec to quit scene and back2lobby
        ExitGame.Instance.ExitScene();
    }

    #endregion
}
