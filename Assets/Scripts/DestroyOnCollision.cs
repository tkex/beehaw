using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
 
    // Name of the tag inside Unity for every beehive component
    // on the conveyor that gets destroyed
    public string beeHiveTagName = "BeeHiveComp";

    [SerializeField] public GameObject prefab; // Drag and drop prefab in unity
    Vector3 objectPos = new Vector3((float)-1.2, (float)1.2, (float)4.5); // Init post to respawn at
    private bool isDestroyed = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(beeHiveTagName))
        {
            Debug.Log("Destroyed");
            Destroy(collision.gameObject);

            isDestroyed = true;
        }        
    }

    private void FixedUpdate()
    {
        // When is destroyed, then respawn prefab to proper posiiton
        if (isDestroyed)
        {
            Instantiate(prefab, objectPos, Quaternion.identity); // Spawn object at position vector3

            // Set isDestroyed to false (otherwise a shitload of new spawned)
            isDestroyed = false;
        }
    }
}
