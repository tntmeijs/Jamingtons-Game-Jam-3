using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject toothPrefab;
    public float interpolationTimeSeconds = 0.75f;
    public float interpolationDistancePixels = 400.0f;
    
    private bool shouldInterpolate;
    private GameObject currentTooth;
    private float interpolationFraction;
    private float baseCameraSize;

    // Use this for initialization
    private void Start()
    {
        shouldInterpolate = false;
        currentTooth = Instantiate(toothPrefab);
        interpolationFraction = 0.0f;
        baseCameraSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentTooth.GetComponent<Tooth>().isFixed && !shouldInterpolate)
        {
            shouldInterpolate = true;
        }

        if (shouldInterpolate)
        {
            interpolationFraction += Time.deltaTime / interpolationTimeSeconds;

            currentTooth.transform.position = new Vector3(  Utils.interpolateAnticipate(interpolationFraction) * interpolationDistancePixels,
                                                            currentTooth.transform.position.y, currentTooth.transform.position.z);

            if (interpolationFraction >= 1.0f)
            {
                Destroy(currentTooth);
                currentTooth = Instantiate(toothPrefab);

                shouldInterpolate = false;
                interpolationFraction = 0.0f;
            }
        }
    }

}
