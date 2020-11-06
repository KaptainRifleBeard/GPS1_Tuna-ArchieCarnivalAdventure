using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] player;
    public GameObject spawnpoint;

    public int randPlayer = 0;
    static int currPlayer;


    void Start()
    {
        randPlayer = Random.Range(0, player.Length);
        if (SelectPlayMode.isDual == true)
        {
            int randP = Random.Range(0, 1);
            player[randP].transform.position = spawnpoint.transform.position;
        }
        else if (SelectPlayMode.isDual == false)
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;
            currPlayer = randPlayer;

        }


        if (WinLoseScreen.isRetryLevel == true)
        {
            player[currPlayer].transform.position = spawnpoint.transform.position;  
        }

    }
}
