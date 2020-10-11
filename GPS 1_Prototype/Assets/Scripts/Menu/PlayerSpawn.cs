using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject player1;
    public GameObject player2;
    public GameObject spawnpoint;

    int numPlayer1 = 0;
    int numPlayer2 = 0;

    void Awake()
    {
        if(numPlayer1 < 1)
        {
            Instantiate(player1, spawnpoint.transform.position, quaternion.identity);
        }

        if (getIsDual())
        {
            Debug.Log("trigger dual");
            if (numPlayer2 < 1)
            {
                Instantiate(player2, spawnpoint.transform.position, quaternion.identity);
            }
        }
    }

}
