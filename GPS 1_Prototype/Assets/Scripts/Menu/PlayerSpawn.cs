using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player;
    public static GameObject playerRespawn;

    public GameObject spawnpoint;

    public int randPlayer = 0;
    public static int currPlayer = 0;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    void Start()
    {    
        randPlayer = Random.Range(0, player.Length);    
        currPlayer = randPlayer;

        Debug.Log("randplayer1 = " + randPlayer);
        Debug.Log("currplayer1 = " + currPlayer);    

        if(!WinLoseScreen.isRetryLevel)
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;  

        }

        Debug.Log(player[currPlayer].name);
        playerRespawn = player[currPlayer];

    }
}
