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

    public void Start()
    {
        randPlayer = Random.Range(0, player.Length);

        player[randPlayer].transform.position = spawnpoint.transform.position;
        if (isDual)
        {
            int randP = Random.Range(0, 1);
            player[randP].transform.position = spawnpoint.transform.position;
        }
        
    }
}
