using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpoint;

    public int randPlayer = 0;
    static int currPlayer;


    void Start()
    {
        randPlayer = Random.Range(0, player.Length);    

        if (WinLoseScreen.isRetryLevel == true)
        {
            player[currPlayer].transform.position = spawnpoint.transform.position;  
        }
        else
        {           
            if (isDual)
            {
                int randP = Random.Range(0, 1);
                player[randP].transform.position = spawnpoint.transform.position;
            }
            else
            {
                player[randPlayer].transform.position = spawnpoint.transform.position;
                currPlayer = randPlayer;
                Debug.Log("last player" + currPlayer);

            }
        }

    }
        
     void Update()
    {
        
    }


}
