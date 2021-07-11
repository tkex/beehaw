using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBee : MonoBehaviour
{
    /// <summary>
    /// File that moves bees along a set of Vector3 coordinates.
    /// </summary>

    #region Variables

    [Tooltip("Set ist of positions for bee to move along.")]
    [SerializeField] public Vector3[] positions;

    // Reference to the ToggleGameObject script attached to the bee.
    private ToggleGameObject _toggledGameObject => GetComponent<ToggleGameObject>();
    // Array of all moving bees.
    private MoveBee[] _movingBees;
    // The IEnumerator for the position movement from A to B.
    private IEnumerator _coroutinePosition;

    #endregion


    #region Functions

    void OnEnable()
    {
        _movingBees = FindObjectsOfType(typeof(MoveBee)) as MoveBee[];
        Transform beeGoTransform = gameObject.transform.Find("BeeBody");

        // Toggle visibility of bee.
        _toggledGameObject.ToggleActive(beeGoTransform.gameObject, true);

        // Start Coroutine to move along Array of positions.
        StartCoroutine(StartPath());

        // Check if all bees have moved.
        bool beesHaveMovedOut = AreAllBeesMoving();

        if (beesHaveMovedOut)
        {
            // TODO: implement winning sound
        }
    }

    // Function that checks if all bees have moved.
    private bool AreAllBeesMoving()
    {
        foreach (MoveBee bee in _movingBees)
        {
            if (bee.isActiveAndEnabled)
            {    
                return true;
            }
        }

        return false;
    }

    // Function that passes each new position in Array to the LerpPosition IEnuumerator.
    public IEnumerator StartPath()
    {
        foreach (Vector3 position in positions)
        {
            _coroutinePosition = LerpPosition(position, 6);

            // Wait until Coroutine is finished before moving to the next position.
            yield return StartCoroutine(_coroutinePosition);
        }
    }

    // Function that moves object to given target position.
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        // The length of the animation time.
        float animationTime = 0;

        // Set initial start position as the current location.
        Vector3 startPosition = transform.position;

        while (animationTime < duration)
        {
            // Lerp with given parameters. 
            transform.position = Vector3.Lerp(startPosition, targetPosition, animationTime / duration);
            animationTime += Time.deltaTime;
            yield return null;
        }

        // Set new current location.
        transform.position = targetPosition;

        yield return new WaitForSeconds(1);
    }

    #endregion
}
