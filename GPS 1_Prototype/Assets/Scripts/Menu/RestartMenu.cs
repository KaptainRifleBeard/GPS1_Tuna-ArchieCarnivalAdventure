using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    
    public void restartLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        //GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in player1s)
        //{
        //    GameObject.Destroy(player);

        //}
        //GameObject[] player2s = GameObject.FindGameObjectsWithTag("Player2");
        //foreach (GameObject player2 in player2s)
        //{
        //    GameObject.Destroy(player2);

        //}

    }

    public void restartLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        //GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in player1s)
        //{
        //    GameObject.Destroy(player);

        //}
        //GameObject[] player2s = GameObject.FindGameObjectsWithTag("Player2");
        //foreach (GameObject player2 in player2s)
        //{
        //    GameObject.Destroy(player2);

        //}

    }
    public void restartFromBoss()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    
    }
}
