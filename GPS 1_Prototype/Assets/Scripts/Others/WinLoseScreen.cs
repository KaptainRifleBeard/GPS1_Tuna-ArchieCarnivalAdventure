using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public bool isRetryLevel = false;
    public void LoadToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isRetryLevel = true;
        GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in player1s)
        {
            GameObject.Destroy(player);

        }
    }
}
