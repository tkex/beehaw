using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    // Name of the tag inside Unity for every beehive component
    // on the conveyor that gets destroyed
    public string beeHiveTagName = "BeeHiveComp";

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(beeHiveTagName))
        {
            Debug.Log("Destroyed");
            Destroy(collision.gameObject);           
        }        
    }
}
