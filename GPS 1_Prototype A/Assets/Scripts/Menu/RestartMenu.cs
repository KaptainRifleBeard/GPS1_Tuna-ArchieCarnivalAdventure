using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class RestartMenu : SelectPlayMode
{
    public GameObject player1;
    public GameObject player2;
    public GameObject spawnpoint;
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void restartFromBoss()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        Instantiate(player1, spawnpoint.transform.position, quaternion.identity);
       
        if (getIsDual())
        {
            Debug.Log("trigger dual");
            Instantiate(player2, spawnpoint.transform.position, quaternion.identity);
        }
    }
}
