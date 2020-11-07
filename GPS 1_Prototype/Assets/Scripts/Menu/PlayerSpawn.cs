using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpoint;

    public int randPlayer = 0;
    public static int currPlayer;

    void Start()
    {
        randPlayer = Random.Range(0, player.Length);
        currPlayer = randPlayer;

        Debug.Log("randplayer = " + randPlayer);
        Debug.Log("currplayer = " + currPlayer);

        player[randPlayer].transform.position = spawnpoint.transform.position;
       

    }

    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        if (healthVisual.p1IsDead == true && y == 4)
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;

        }
    }
}
