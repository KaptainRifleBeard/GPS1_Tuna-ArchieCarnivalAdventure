using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public static bool isRetryLevel;
    public GameObject winscreen;
    public GameObject storepoint;

    //public GameObject p1_dart;
    //public GameObject p1_uni;
    //public GameObject p2_water;
    //public GameObject p2_cheese;
    void Start()
    {
        isRetryLevel = false;   
    }

    public void LoadToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winscreen.SetActive(true);
        }


    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isRetryLevel = true;

        GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in player1s)
        {
            //GameObject.Destroy(player);
            player.transform.position = storepoint.transform.position;

        }
    }
    public void RetryLevelfromLevel3()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //isRetryLevel = true;

        //GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in player1s)
        //{
        //    GameObject.Destroy(player);

        //}
        //p1_dart.SetActive(true);
        //p1_uni.SetActive(true);
        //p2_water.SetActive(true);
        //p2_cheese.SetActive(true);
    }

}
