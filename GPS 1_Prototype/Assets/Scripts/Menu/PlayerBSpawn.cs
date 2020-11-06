using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpointB;

    public int randPlayer = 0;

    public void Start()
    {
        randPlayer = Random.Range(0, player.Length);

        if (isDual)
        {
            Debug.Log("trigger dual");
            player[randPlayer].transform.position = spawnpointB.transform.position;
        }
    }
}
