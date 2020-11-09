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
    public int currPlayer = 0;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    void Start()
    {    
        randPlayer = Random.Range(0, player.Length);    
        currPlayer = randPlayer;

        Debug.Log("randplayer = " + randPlayer);
        Debug.Log("currplayer = " + currPlayer);    

        if(!WinLoseScreen.isRetryLevel)
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;  
        }


        Debug.Log(player[currPlayer].name);
        playerRespawn = player[currPlayer];




        //if (currPlayer == 0)
        //{
        //    WeaponIcon.image.sprite = dart_icon;

        //}
        //if (currPlayer == 1)
        //{

        //    WeaponIcon.image.sprite = uni_icon;

        //}
    }
}
