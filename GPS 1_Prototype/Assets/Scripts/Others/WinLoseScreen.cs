using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public static bool isRetryLevel;
    public GameObject winscreen;
    public GameObject spawnpoint;
    public GameObject storepoint;
    public GameObject[] player;

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

        int y = SceneManager.GetActiveScene().buildIndex;
        isRetryLevel = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in players)
        //{
        //    if (y == 4)
        //    {
        //        GameObject.Destroy(player);
        //        Instantiate(player, storepoint.transform.position, Quaternion.identity);

        //    }
        //    else
        //    {
        //        GameObject.Destroy(player);
        //    }
        //}


        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = spawnpoint.transform.position;
        //GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in player1s)
        //{
        //    //GameObject.Destroy(player);

        //}
    }

}
