using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause)
            {
                //resume game
                pause = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                //pause game
                pause = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;  //stop the game
                
            }

        }
        
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void resume()
    {
        //resume game
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
