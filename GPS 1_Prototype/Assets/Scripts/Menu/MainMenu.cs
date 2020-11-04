using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void howToPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void buttonClick()
    {
        FindObjectOfType<AudioManager>().Play("ButtonPress");
    }

    public void ContinueToLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void ContinueToLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
