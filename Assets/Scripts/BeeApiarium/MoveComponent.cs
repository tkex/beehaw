using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for moving objects on the conveyor.
    /// </summary>

    #region Variables

    // Declare rigidbody varible.
    private Rigidbody _rigidbody;

    [Tooltip("Numerical value of moving speed on the belt.")]
    [SerializeField] private float _speedAmount = 0.4f;

    #endregion


    #region Functions

    void Start()
    {
        // Assign the Rigidbody Components to the rb variable.
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Save current rigibody position in currentPosition variable.
        Vector3 currentPosition = _rigidbody.position;

        // Increase the rigibody position incremental by forward its position relative to time and speed.
        _rigidbody.position += Vector3.forward * _speedAmount * Time.fixedDeltaTime;

        // Move object position by applying the current position.
        _rigidbody.MovePosition(currentPosition);

    }

    #endregion
}
