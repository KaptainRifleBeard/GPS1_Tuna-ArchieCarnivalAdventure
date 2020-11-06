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
    public int currPlayerNum;


    public void Start()
    {
        randPlayer = Random.Range(0, player.Length);
        currPlayerNum = randPlayer;

        if (isDual)
        {
            int randP = Random.Range(0, 1);
            player[randP].transform.position = spawnpoint.transform.position;
        }
        else
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;
        }


    }
    void update()
    {

        if (GetComponent<WinLoseScreen>().isRetryLevel == true)
        {
            if (currPlayerNum == 0)
            {
                player[0].transform.position = spawnpoint.transform.position;

            }
            else if (currPlayerNum == 1)
            {
                player[1].transform.position = spawnpoint.transform.position;

            }
            else if (currPlayerNum == 2)
            {
                player[2].transform.position = spawnpoint.transform.position;

            }
            else if (currPlayerNum == 3)
            {
                player[3].transform.position = spawnpoint.transform.position;

            }
        }


    }
}
