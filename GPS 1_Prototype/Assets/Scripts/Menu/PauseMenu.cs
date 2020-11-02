using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public bool restart = false;
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
        restart = true;
        GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in player1s)
        {
            GameObject.Destroy(player);

        }
        GameObject[] player2s = GameObject.FindGameObjectsWithTag("Player2");
        foreach (GameObject player2 in player2s)
        {
            GameObject.Destroy(player2);

        }

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    public void resume()
    {
        //resume game
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
