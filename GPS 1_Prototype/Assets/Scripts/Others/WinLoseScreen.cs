using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public static bool isRetryLevel;
    public static healthVisual health;

    public GameObject loseScreen;
    public GameObject spawnpoint;

    void Start()
    {   
        isRetryLevel = false;   
    }

    public void LoadToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


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

            Application.LoadLevel(Application.loadedLevel);
            //healthVisual.HealthSystem.addHealth(6);
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