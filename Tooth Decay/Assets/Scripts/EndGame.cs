using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public Text finalScoreLabel;
    public Text highScore;

    private static int previousHighScore = 0;

    // Use this for initialization
    private void Start()
    {
        UnityEngine.Cursor.visible = true;
        finalScoreLabel.text = "You managed to score " + GameManager.score.ToString() + " points!";

        if (GameManager.score > previousHighScore)
        {
            if (previousHighScore == 0)
            {
                highScore.text = "You've set the first high-score, can you beat it?";
            }
            else
            {
                highScore.text = "Your score is " + ((int)(((float)previousHighScore / GameManager.score) * 100)).ToString() + "% higher than the previous high-score(" + previousHighScore + ")!";
            }

            previousHighScore = GameManager.score;
        }
        else
        {
            highScore.text = "High score: " + GameManager.score + ".";
        }
    }

    public void restart()
    {
        // Load the previous scene, the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
