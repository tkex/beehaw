using UnityEngine;

public class AngleBasedParticleActivationScript : MonoBehaviour
{
    /// <summary>
    /// File that activates particles between two given angles.
    /// </summary>

    #region Variables

    [Header("Position Configuration")]

    [Tooltip("Set Particle System.")]
    [SerializeField] private ParticleSystem _particle;

    [Tooltip("Minimum angle at which the Particle System will be played.")]
    [SerializeField] private float _minAngle;

    [Tooltip("Maximum angle at which the Particle System will be played.")]
    [SerializeField] private float _maxAngle;

    private bool _particlePlayed = false;

    #endregion


    #region Functions
    void Start()
    {
        // Calculations for angles to represent the same as Rotation value.
        _minAngle = Mathf.Repeat(_minAngle + 180, 360) - 180;
        _maxAngle = Mathf.Repeat(_maxAngle + 180, 360) - 180;
    }

    void Update()
    {
        // Angles at which the Particle System will be played.
        if (transform.rotation.eulerAngles.x > _minAngle && transform.rotation.eulerAngles.x < _maxAngle)
        {
            // Check if the particles haven't played already and play them.
            if (!_particlePlayed) {
                 ParticleManager.Instance.PlayParticle(_particle);
                 _particlePlayed = true;
             }
        } 
        else 
        {
            // If angle has exceeded the given values, stop particles.
            _particle.Stop();
            _particlePlayed = false;
        }
    }

    #endregion
}
