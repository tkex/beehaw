using UnityEngine;

public class AngleBasedParticleActivationScript : MonoBehaviour
{
    /// <summary>
    /// File that activates particles between two given angles.
    /// </summary>

    #region Variables

    [Header("Position Configuration")]

    [Tooltip("Set Particle System.")]
    [SerializeField] private ParticleSystem particle;

    [Tooltip("Minimum angle at which the Particle System will be played.")]
    [SerializeField] private float minAngle;

    [Tooltip("Maximum angle at which the Particle System will be played.")]
    [SerializeField] private float maxAngle;

    private bool particlePlayed = false;

    #endregion


    #region Functions
    void Start()
    {
        // Calculations for angles to represent the same as Rotation value.
        minAngle = Mathf.Repeat(minAngle + 180, 360) - 180;
        maxAngle = Mathf.Repeat(maxAngle + 180, 360) - 180;
    }

    void Update()
    {
        // Angles at which the Particle System will be played.
        if (transform.rotation.eulerAngles.x > minAngle && transform.rotation.eulerAngles.x < maxAngle)
        {
            // Check if the particles haven't played already and play them.
            if (!particlePlayed) {
                 ParticleManager.Instance.PlayParticle(particle);
                 particlePlayed = true;
             }
        } 
        else 
        {
            // If angle has exceeded the given values, stop particles.
            particle.Stop();
            particlePlayed = false;
        }
    }

    #endregion
}
