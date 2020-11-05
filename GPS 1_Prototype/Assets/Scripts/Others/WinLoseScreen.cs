using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public void LoadToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
