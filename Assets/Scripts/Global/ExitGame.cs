using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for exiting the scene.
    /// </summary>

    #region Variables

    // Scene index value variable for scene loading (see menu build settings for an overview).
    [Tooltip("Scene index value for the next loading scene after winning.")]
    [SerializeField] private int _lobbyIndexValue;

    // Seconds until scene exit
    [Tooltip("Numerical time value in seconds before loading the next scene.")]
    [SerializeField] private int _secondsForExit = 7;

    #endregion


    // Declare Singleton.
    #region Singleton

    // Declare ExitGame Singleton instance.
    public static ExitGame Instance;

    // Initialize the singleton instance when script instance is being loaded.
    private void Awake()
    {
        // Set instance of ExitGame to this.
        Instance = this;
    }

    #endregion


    #region Functions

    // Function for exiting the scene.
    public void ExitScene()
    {
        // Invoke LoadSceneByIndex function with the numerical timer as parameter.
        Invoke("LoadSceneByIndex", _secondsForExit);
    }

    // Function for containing the logic for loading the next scene in context of SceneManager.
    public void LoadSceneByIndex()
    {
        // LoadScene with set index value.
        SceneManager.LoadScene(_lobbyIndexValue);
    }

    #endregion
}
