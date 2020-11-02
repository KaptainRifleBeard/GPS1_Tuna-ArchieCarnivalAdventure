using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class RestartMenu : PlayerSpawn
{
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

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

    }
    public void restartFromBoss()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    
    }
}
