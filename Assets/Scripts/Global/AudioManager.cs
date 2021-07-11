using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic and management for the sound sources.
    /// </summary>

    #region Variables

    // Sound Configuration.
    [Header("Sound Configuration")]

    [Tooltip("Set AudioSource to the GameObject that contains the axeHit sound clip.")]
    [SerializeField] private AudioSource _axeSoundSource;

    [Tooltip("Set AudioSource to the GameObject that contains the winning sound clip.")]
    [SerializeField] private AudioSource _winningSoundSource;

    #endregion


    // Singleton.
    #region Singleton

    // Declare Audiomanager Singleton instance.
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;  
    }

    #endregion


    #region Functions

    // Function for playing a sound for the axe hitting.
    public void PlayAxeSoundOnceAfterHit(AudioClip clip)
	{
        // Play axeHit sound clip through the AudioSource.
        _axeSoundSource.clip = clip;
        _axeSoundSource.Play();
	}

    // Function for playing the winning sound afte winning the game.
    public void PlayWinningSound(AudioClip clip)
    {
        _winningSoundSource.clip = clip;
        _winningSoundSource.Play();
    }

    #endregion
}
