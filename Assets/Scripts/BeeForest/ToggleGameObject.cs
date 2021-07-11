using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    /// <summary>
    /// File that handles Active and Inactive status of any given Game Object.
    /// Can be further expanded to include effects like Fading In/Out.
    /// </summary>
    
    public void ToggleActive(GameObject gameObject, bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
