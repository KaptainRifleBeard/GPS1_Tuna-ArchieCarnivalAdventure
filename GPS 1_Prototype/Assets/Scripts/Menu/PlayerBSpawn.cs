using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpointB;
    public static GameObject playerBRespawn;

    public int randP = 0;
    public static int cPlayer = 0;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    public void Start()
    {
        if (isDual)
        {
            Debug.Log("trigger dual");

            if (!WinLoseScreen.isRetryLevel)
            {
                randP = Random.Range(0, player.Length);
                cPlayer = randP;

                Debug.Log("randplayer2 = " + randP);
                Debug.Log("currplayer2 = " + cPlayer);

                player[randP].transform.position = spawnpointB.transform.position;

                Debug.Log(player[cPlayer].name);
                playerBRespawn = player[cPlayer];
            }
            
        }
        
    }


}
