using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    Rigidbody rigidBody;
    public float speedAmount = 0.6f;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 position = rigidBody.position;
        rigidBody.position += Vector3.forward * speedAmount * Time.fixedDeltaTime;

        rigidBody.MovePosition(position);
    }
}
