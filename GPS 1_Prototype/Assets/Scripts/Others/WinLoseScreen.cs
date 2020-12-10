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
        isRetryLevel = false;
    }

    public void RetryLevel()
    {
        GameObject[] allPlayer = GameObject.FindGameObjectsWithTag("Player");

        if (SelectPlayMode.isDual == true)
        {
            if (healthVisual.p1IsDead == true && healthVisualB.p2IsDead == true)
            {
                Application.LoadLevel(Application.loadedLevel);
                //Scene scene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
                if (healthVisual.p1IsDead == true)
                {
                    PlayerSpawn.playerRespawn.SetActive(true);

                }
                if (healthVisualB.p2IsDead == true)
                {
                    PlayerBSpawn.playerBRespawn.SetActive(true);

                }


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
                //Scene scene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
                PlayerSpawn.playerRespawn.SetActive(true);

                PlayerSpawn.playerRespawn.transform.position = spawnpoint.transform.position;
                isRetryLevel = true;
                loseScreen.SetActive(false);
                StartCoroutine(stopRetryLevel());

            }
        }
        

    }

    /*
    public void Update()
    {
        if (HeartSystem.p1IsDead == true)
        {
            loseScreen.SetActive(true);
            if(isRetryLevel)
            {
                loseScreen.SetActive(false);
                HeartSystem.p1IsDead = false;
                StartCoroutine(stopRetryLevel());


            }
        }

    }
    */
}



//GameObject player = GameObject.FindGameObjectWithTag("Player");
//player.transform.position = spawnpoint.transform.position;
//GameObject[] player1s = GameObject.FindGameObjectsWithTag("Player");
//foreach (GameObject player in player1s)
//{
//    //GameObject.Destroy(player);

//}