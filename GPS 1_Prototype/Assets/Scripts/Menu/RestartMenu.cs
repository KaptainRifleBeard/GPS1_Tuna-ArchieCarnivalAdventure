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

    }

    public void restartLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

    }
    public void restartFromBoss()
    {
        //SceneManager.LoadScene(7);
        if (SelectPlayMode.isDual == true)
        {
            if (healthVisual.p1IsDead == true && healthVisualB.p2IsDead == true)
            {
                Application.LoadLevel(7);
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


                PlayerSpawn.playerRespawn.transform.position = new Vector3(-119.8f, 28.3f, -5.50f);
                PlayerBSpawn.playerBRespawn.transform.position = new Vector3(-119.8f, 28.3f, -5.50f);


            }
        }
        else if (SelectPlayMode.isDual == false)
        {
            if (healthVisual.p1IsDead == true)
            {
                Application.LoadLevel(7);
                //Scene scene = SceneManager.GetActiveScene();
                //SceneManager.LoadScene(scene.name);
                PlayerSpawn.playerRespawn.SetActive(true);

                PlayerSpawn.playerRespawn.transform.position = new Vector3(-119.8f, 28.3f, -5.50f);


            }
        }

    }
}



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
