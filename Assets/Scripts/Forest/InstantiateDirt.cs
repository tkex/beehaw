using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDirt : MonoBehaviour
{
    private float nextSpawnTime;
    [SerializeField] public GameObject prefab; // Drag and drop prefab to component in unity
    
    private void Update() {
        if(ShouldSpawn()) {
            Spawn();
        }
    }

    public void Spawn() {
        /* 
        * Unity Docs:
        * The identity rotation (Read Only).
        * This quaternion corresponds to "no rotation" - the object is perfectly aligned with the world or parent axes.
        */
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    private bool ShouldSpawn() {
        return Time.time > nextSpawnTime;
    }
}
