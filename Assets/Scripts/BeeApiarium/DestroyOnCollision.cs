using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DestroyOnCollision : MonoBehaviour
{

    /// <summary>
    /// File that contains the logic for destroying conveyor items through
    /// their assigned tags.
    /// </summary>

    #region Variables

    // Declare here every tag that get destroyed upon Collision detection.
    // Additional tags must firstly be created in Unity.
    [Tooltip("String elements of tags that get destroyed. Each tag will be checked and destroyed.")]
    [SerializeField] private string[] _checkingTag = {"Stand", "Storey", "QueenExcluder", "InnerCover", "Roof"};

    #endregion


    #region Functions    

    // Function for detecting collision with the ground and destroying objects with the above defined tags.
    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < _checkingTag.Length; i++)
        {
            // Check if colliding gameobject contains defined tag.
            if (collision.gameObject.CompareTag(_checkingTag[i]))
            {
                // Call instance of ResetGoFromPool function in ObjectPool class.
                ObjectPool.Instance.ResetGoFromPool(collision.gameObject, _checkingTag[i]);
            }
        }
    }

    #endregion
}
