using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ItemExchange : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for exchanging the woodlog for a roof (item exchange).
    /// </summary>


    #region Variables

    [Header("Gameobject Configuration")]
    // Tag of gameobject that will be destroyed upon collision.
    // Each gameobject that contains this specific tag is destroyable in the scene.
    [Tooltip("Assigned tag of the GameObject that will be destroyed.")]
    [SerializeField] private string _tagOfDestroyingItem;

    // Gameobject prefab of the object that will be spawned into the scene.
    [Tooltip("Set Prefab of GameObject that will be spawned.")]
    [SerializeField] private GameObject _newGo;


    [Header("Position Configuration")]
    // Variable for saving the position of the destroyed gameobject for spawning the
    // new gameobject at the exact same location.
    private Vector3 _positionOfOldGo;

    [Tooltip("Y-Offset for the new spawning gameobject.")]
    [SerializeField] private float _newGoSpawnYOffset = 1.5f;

    [Tooltip("Timer delay for the new spawning gameobject.")]
    [SerializeField] private float _spawnTimeNewGo = 0.7f;

    // In case item should drop with another rotation
    [Tooltip("Rotation for the new spawning gameobject.")]
    [SerializeField] private Quaternion _rotationNewGo = Quaternion.Euler(270, 90, 0);


    // AudioSource that will be used by the AudioManager class.
    [Header("Audio Setup")]
    // AudioClip that will used and played upon collision.
    [Tooltip("Set audio file that will be played once the collision occurs.")]
    [SerializeField] private AudioClip _collisionSoundClip;

    #endregion


    #region Functions

    // Function for destroying a gameobject and spawning another gameobject in its place.
    private void OnCollisionEnter(Collision collision)
    {
        // Check collision for a gameobject via tag string.  
        if (collision.gameObject.CompareTag(_tagOfDestroyingItem))
        {
            // Call instance of PlayAxeSoundOnceAfterHit function in AudioManager class.
            AudioManager.Instance.PlayAxeSoundOnceAfterHit(_collisionSoundClip);
  
            // Destroy colliding game object (woodlog).
            Destroy(collision.gameObject);
            // Debug.Log("Destroyed " + collision.gameObject);

            // Set position of the destroying object (woodlog) as the spawn point for the new gameobject.
            _positionOfOldGo = collision.gameObject.transform.position;

            // Invoke time-delayed prefab spawn (roof).
            Invoke("SpawnItem", _spawnTimeNewGo);
        }   
    }


    // Function for spawning a new defined gameobject.
    void SpawnItem()
    {
        // Set new position for the new spawning gameobject.
        // Assign the old gameobject position to Vector3 position variable.
        Vector3 position = _positionOfOldGo;
        // Increase value of Y-position by defined spawn offset.
        position.y += _newGoSpawnYOffset;
        // Set to spawn gameobject with changed Vector3 position.
        _positionOfOldGo = position;

        // Instantiate a new gameobject with changed position and rotation.
        Instantiate(_newGo, _positionOfOldGo, _rotationNewGo);
    }

    #endregion
}
