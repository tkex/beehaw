using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for starting the game.
    /// </summary>

    #region Variables

    // Scene index value variable for scene start (see menu build settings for an overview).
    [Tooltip("Scene index value for the first loading scene.")]
    [SerializeField] private int _firstSceneIndexValue = 1;

    #endregion


    #region Functions

    public void StartScene()
    {
        // LoadScene with set index value.
        SceneManager.LoadScene(_firstSceneIndexValue);
    }

    #endregion
}
