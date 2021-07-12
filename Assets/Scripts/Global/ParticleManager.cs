using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic and management for the particle effects.
    /// </summary>

    // Singleton.
    #region Singleton

    // Declare Particle Manager Singleton instance.
    public static ParticleManager Instance;

    // Initialize the singleton instance when script instance is being loaded.
    private void Awake()
    {
        // Set instance of ParticleManager to this.
        Instance = this;
    }

    #endregion


    #region Functions

    // Function for spawning a particle.
    public void SpawnParticle(GameObject particleGo, Vector3 particlePosition, Quaternion particleRotation)
    {
        // Instantiate a new particle.
        Instantiate(particleGo, particlePosition, Quaternion.identity);
    }

    // Function for playing a particle from Particle System.
    public void PlayParticle(ParticleSystem particleSystem)
    {
        particleSystem.Play();
    }

    #endregion
}
