using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public static bool isRetryLevel;
    public GameObject loseScreen;

    //public GameObject winscreen;
    public GameObject spawnpoint;
    //public GameObject storepoint;
    //public GameObject[] player;

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

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        winscreen.SetActive(true);
    //    }


    //} 

    public IEnumerator stopRetryLevel()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("is retry = false");
        isRetryLevel = false;
    }

    public void RetryLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (healthVisual.p1IsDead == true)
        {
            PlayerSpawn.playerRespawn.transform.position = spawnpoint.transform.position;
            isRetryLevel = true;
            loseScreen.SetActive(false);
            StartCoroutine(stopRetryLevel());

            healthVisual.HealthSystem.addHealth(6);
        }

    }

}





//GameObject player = GameObject.FindGameObjectWithTag("Player");
//player.transform.position = spawnpoint.transform.position;
//GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
//foreach (GameObject player in player1s)
//{
//    //GameObject.Destroy(player);

//}