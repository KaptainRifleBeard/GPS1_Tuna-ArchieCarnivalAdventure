using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject player1;
    public GameObject player2;
    public GameObject spawnpoint;

    void Start()
    {
        player1.transform.position = spawnpoint.transform.position;

        if (getIsDual())
        {
            Debug.Log("trigger dual");
            player2.transform.position = spawnpoint.transform.position;
            player1.transform.position = spawnpoint.transform.position;


        }
    }

}
