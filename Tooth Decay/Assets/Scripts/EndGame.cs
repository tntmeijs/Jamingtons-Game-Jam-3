using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public Text finalScoreLabel;
    public Text percentageLabel;

    // Use this for initialization
    private void Start()
    {
        UnityEngine.Cursor.visible = true;
        finalScoreLabel.text = "You managed to score " + GameManager.score.ToString() + " points!";

        if (GameManager.previousScore > GameManager.score)
        {
            percentageLabel.text = "Wow, you've improved by " + (GameManager.score / GameManager.previousScore * 100).ToString() + " percent!";
        }
        else
        {
            if (GameManager.previousScore == 0)
            {
                percentageLabel.text = "Come on, give it another shot!";
            }

            percentageLabel.text = "Aww, you did not do better than last time...";
        }

        GameManager.previousScore = GameManager.score;
    }

    public void restart()
    {
        // Load the previous scene, the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
