using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    public static bool isRetryLevel;

    public static healthVisual health;
    public static healthVisualB healthB;

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

        if(SelectPlayMode.isDual == true)
        {
            if (healthVisual.p1IsDead == true && healthVisualB.p2IsDead == true)
            {
                Application.LoadLevel(Application.loadedLevel);

                PlayerSpawn.playerRespawn.transform.position = spawnpoint.transform.position;
                PlayerBSpawn.playerBRespawn.transform.position = spawnpoint.transform.position;

                isRetryLevel = true;
                loseScreen.SetActive(false);
                StartCoroutine(stopRetryLevel());

            }
        }
        else if (SelectPlayMode.isDual == false)
        {
            if (healthVisual.p1IsDead == true)
            {
                Application.LoadLevel(Application.loadedLevel);

                PlayerSpawn.playerRespawn.transform.position = spawnpoint.transform.position;
                isRetryLevel = true;
                loseScreen.SetActive(false);
                StartCoroutine(stopRetryLevel());

            }
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