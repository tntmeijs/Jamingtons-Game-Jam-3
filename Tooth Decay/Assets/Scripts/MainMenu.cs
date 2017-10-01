using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Image instructions;
    public Button play;
    public Button help;
    public Button back;

    private void Start()
    {
        // Default states
        play.gameObject.SetActive(true);
        help.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
    }

    public void playGame()
    {
        // Load the next scene (game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void showInstructions()
    {
        play.gameObject.SetActive(false);
        help.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        instructions.gameObject.SetActive(true);
    }

    public void backToMain()
    {
        play.gameObject.SetActive(true);
        help.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
    }

}
