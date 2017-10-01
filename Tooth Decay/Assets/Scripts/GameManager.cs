using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject toothPrefab;
    public Text scoreLabel;
    public Text timerLabel;
    public float interpolationTimeSeconds = 0.75f;
    public float interpolationDistancePixels = 400.0f;
    public static int score = 0;
    public float gameTimerStart = 25.0f;

    private string scorePrefix = "Score: ";
    private string timerPrefix = "";
    private string timerPostfix = " seconds left!";
    private bool shouldInterpolate;
    private GameObject currentTooth;
    private float interpolationFraction;
    private float gameTimerAccumulator;

    // Use this for initialization
    private void Start()
    {
        UnityEngine.Cursor.visible = false;

        score = 0;

        shouldInterpolate = false;
        currentTooth = Instantiate(toothPrefab);
        interpolationFraction = 0.0f;

        scoreLabel.text = scorePrefix + score.ToString();
        timerLabel.text = timerPrefix + ((int)gameTimerStart).ToString() + timerPostfix;
    }

    // Update is called once per frame
    private void Update()
    {
        // Update the score
        scoreLabel.text = scorePrefix + score.ToString();

        // Update the timer
        gameTimerAccumulator += Time.deltaTime;

        if (gameTimerStart - gameTimerAccumulator <= 1.0f)
        {
            timerPostfix = " second left!";
        }

        if (gameTimerAccumulator >= gameTimerStart)
        {
            gameTimerAccumulator = gameTimerStart;
            gameTimerAccumulator = 0.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        timerLabel.text = timerPrefix + ((int)(gameTimerStart - gameTimerAccumulator)).ToString() + timerPostfix;

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
