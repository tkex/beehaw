using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    /// <summary>
    /// File that contains the objectPoolQueue design pattern for storing gameobjects in an efficient manner.
    /// </summary>

    /// <summary>
    /// The idea:
    /// A pool stores a certain type of object with a defined pool size and an identifier (tag).
    /// Thus each pool is reponsible for a certain reoccuring gameobject in the scene (f.e. roof, cover, ...).
    /// For quick access and to return them in the order in which they were inserted, a queue is used.
    /// The GameObjects of pool will be stored inside a queue. Ob   To store a pool queue, a dictionary is used. 
    /// It's storing the individual and defined pool queues  and can be accessed over the respective tag (string).
    /// </summary>

    #region Pool Class
    [System.Serializable]
    // Define a pool and it's attributes.
    public class Pool
    {
        // GameObject (Prefab) of the pool.
        [Tooltip("Prefab of a GameObject that will be set in the pool.")]
        public GameObject poolGo;

        // Tag of the pool to classifies the specific pool.
        [Tooltip("Tag of the pool that identifies the pool.")]
        public string poolTag;

        // Size of the specific pool.
        [Tooltip("Size of the pool that specifies how much elements it contains.")]
        public int poolSize;
    }
    #endregion

    // Dictionary for storing a queue (that will contain the pool GameObjects).
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    // List for storing the pools.
    public List<Pool> poolsList;


    // Singleton.
    #region Singleton

    // Declare objectPoolQueue Singleton instance.
    public static ObjectPool Instance;

    private void Awake()
    {
        // Set instance of objectPoolQueueer to this.
        Instance = this;
    }

    #endregion


    #region Functions

    void Start()
    { 
        // Create new dictionary in poolDictionary
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // Go through the pools in the list.
        foreach(Pool pool in poolsList)
        {
            // Create a new queue for each pool.
            Queue<GameObject> objectPoolQueue = new Queue<GameObject>();

            // Go through the size of each pool.
            for (int i = 0; i< pool.poolSize; i++)
            {
                // Create a new GameObject (per pool iteration).
                GameObject go = Instantiate(pool.poolGo);

                // Set (each) GameObject inactive (disable in scene).
                go.SetActive(false);

                // Add (each) GameObject to its pool queue.
                objectPoolQueue.Enqueue(go);
            }

            // Once each pool is filled with their respective gameobjects, add (respective) pool to the dictionary for storing it.
            poolDictionary.Add(pool.poolTag, objectPoolQueue);
        }
    }

    // Function for spawning a GameObject from the pool..
    public GameObject SpawnGoFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        // Get the spawning GameObject from poolDictionary pool queue (always front element).
        GameObject spawningGo = poolDictionary[tag].Dequeue();

        // Set spawning GameObject active (enable in scene).
        spawningGo.SetActive(true);

        // Set spawning GameObject positon via parameter.
        spawningGo.transform.position = position;

        // Set spawning GameObject rotation via parameter.
        spawningGo.transform.rotation = rotation;

        // Set spawning GameObject back into the queue (always back element).
        //poolDictionary[tag].Enqueue(spawningGo);

        // Return spawning GameObject.
        return spawningGo;
    }

    // Function for deactivating and enqueue a GameObject back into the pool.
    public void ResetGoFromPool(GameObject despawnGo, string tag)
    {
        // Set GameObject inactive (disable in scene).
        despawnGo.SetActive(false);

        // Put GameObject back into the queue again.
        poolDictionary[tag].Enqueue(despawnGo);

        //Debug.Log(go +  "is deactivated.");
    }

    #endregion
}
