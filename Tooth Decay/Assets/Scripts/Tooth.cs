using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{

    public bool isFixed = false;
    public float interpolationTimeSeconds = 2.5f;

    private bool shouldInterpolate;
    private float targetScale;
    private float interpolationAccumulator;

    // Use this for initialization
    private void Start()
    {
        // The scale is uniform, so x == y
        targetScale = transform.localScale.x;

        // Reset the scale (this will be increased by using the interpolation function below
        transform.localScale = new Vector2(0.0f, 0.0f);

        shouldInterpolate = true;
        interpolationAccumulator = 0.0f;
    }

    private void LateUpdate()
    {
        if (DamageSpawner.holesLeftToPolish == 0)
        {
            isFixed = true;
        }
    }

    private void Update()
    {
        if (shouldInterpolate)
        {
            interpolationAccumulator += Time.deltaTime / interpolationTimeSeconds;

            if (interpolationAccumulator >= 1.0f)
            {
                interpolationAccumulator = 1.0f;
                shouldInterpolate = false;
            }

            float newScale = Utils.interpolateSpring(interpolationAccumulator) * targetScale;
            transform.localScale = new Vector2(newScale, newScale);
        }
    }

}
