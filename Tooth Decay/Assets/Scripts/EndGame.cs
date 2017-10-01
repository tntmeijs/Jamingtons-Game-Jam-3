using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public Text finalScoreLabel;

    // Use this for initialization
    private void Start()
    {
        UnityEngine.Cursor.visible = true;
        finalScoreLabel.text = "You managed to score " + GameManager.score.ToString() + " points!";
    }

    public void restart()
    {
        // Load the previous scene, the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
