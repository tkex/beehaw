using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateFlowerGrowth : MonoBehaviour
{
    /// <summary>
    /// File that contains a basic implementation for flower growth.
    /// </summary>

    #region Variables

    // private Vector3 _minScale;
    // private Vector3 _maxScale;
    // private Vector3 _minPosition;
    // private Vector3 _maxPosition;
    private float _yUndergroundPosition = -1.25f;

    [Header("Growth Configuration")]
    [Tooltip("Set speed of growth.")]
    [SerializeField] private float _speed = 2f;

    [Tooltip("Set duration of growth.")]
    [SerializeField] private float _duration = 5f;

    #endregion


    #region Functions
    private void OnEnable()
    {
        // Starting Couroutines.
        StartCoroutine(StartTransform());
        StartCoroutine(StartScaling());
    }

    private IEnumerator StartScaling()
    {
        // Set initial scale to 0.
        Vector3 _minScale = new Vector3(0, 0, 0);
        // Set maximum scale to object's initial scale.
        Vector3 _maxScale = transform.localScale;

        yield return ScaleLerp(_minScale, _maxScale, _duration);
    }

    private IEnumerator StartTransform()
    {
        // Set minPosition to object's initial position (for X and Z-values).
        Vector3 _minPosition = transform.localPosition;
        // Set Y-Offset so the object is underground.
        _minPosition.y = _yUndergroundPosition;
        // Set maximum position to object's initial position.
        Vector3 _maxPosition = transform.localPosition;
       
        yield return TransformLerp(_minPosition, _maxPosition, _duration);
    }

    // Function that scales up/down between two vectors at a given duration and speed.
    private IEnumerator ScaleLerp(Vector3 a, Vector3 b, float time)
    {
        // The length of the animation time.
        float animationTime = 0.0f;
        // The rate at which the Lerp will scale the object.
        float rate = (1.0f / time) * _speed;

        while (animationTime < 1.0f)
        {
            // Lerp with given parameters.
            animationTime += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, animationTime);

            yield return null;
        }
    }

    // Function that moved up/down between two vectors at a given duration and speed.
    private IEnumerator TransformLerp(Vector3 a, Vector3 b, float time)
    {
        // The length of the animation time.
        float animationTime = 0.0f;
        // The rate at which the Lerp will scale the object.
        float rate = (1.0f / time) * _speed;

        while (animationTime < 1.0f)
        {
            // Lerp with given parameters. 
            animationTime += Time.deltaTime * rate;
            transform.localPosition = Vector3.Lerp(a, b, animationTime);

            yield return null;
        }
    }

    #endregion
}
