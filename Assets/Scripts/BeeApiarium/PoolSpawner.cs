using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for spawning gameobjects from the objectpool.
    /// </summary>

    #region Variables

    [Header("Positon and Rotation Settings")]

    // The positions of spawning gameobjects.
    [Tooltip("Position for the Stand GameObjects.")]
    [SerializeField] private Vector3 _standSpawnPosition = new Vector3(-1.2f, 2f, 4.5f);

    [Tooltip("Position for the Storey GameObjects.")]
    [SerializeField] private Vector3 _storeySpawnPosition = new Vector3(-1.2f, 2f, 7.0f);

    [Tooltip("Position for the QueenExcluder GameObjects.")]
    [SerializeField] private Vector3 _queenExcluderSpawnPosition = new Vector3(-1.2f, 2f, 8.0f);

    [Tooltip("Position for the InnerCover GameObjects.")]
    [SerializeField] private Vector3 _innerCoverSpawnPosition = new Vector3(-1.2f, 2f, 9.5f);

    // The rotation of spawning gameobjects.
    [Tooltip("Rotation for all spawning GameObjects.")]
    [SerializeField] private Quaternion _goSpawnRotation = Quaternion.Euler(270, 90, 0);

    // Delay for gameobject spawning.
    [Header("Timer Settings")]
    [Tooltip("Set interval delay for spawning group of GameObjects from the pool.")]
    [SerializeField] private float delay = 22.0f;
    private float lastTime;

    #endregion


    #region Functions
    void FixedUpdate ()
    {
        // Check if passed time is greater than set delay value.
        if(Time.time - lastTime > delay)
        {
            // Set ObjectPool instances that will be (timely) spawned in the scene via defined tags.
            // The spawn pool is configured in the ObjectPool gameobject in Unity.

            // Call instance of SpawnGoFromPool function in ObjectPool class.
            ObjectPool.Instance.SpawnGoFromPool("Stand", _standSpawnPosition, _goSpawnRotation);

            ObjectPool.Instance.SpawnGoFromPool("Storey", _storeySpawnPosition, _goSpawnRotation);

            ObjectPool.Instance.SpawnGoFromPool("QueenExcluder", _queenExcluderSpawnPosition, Quaternion.identity);

            ObjectPool.Instance.SpawnGoFromPool("InnerCover", _innerCoverSpawnPosition, Quaternion.identity);

            // Set Time to lastTime variable for timecritical execution.
            lastTime = Time.time;
        }
    }

    #endregion
}
