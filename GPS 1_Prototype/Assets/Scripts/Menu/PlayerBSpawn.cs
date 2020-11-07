using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpointB;

    [SerializeField] public static int randP = 0;

    public void Start()
    {
        randP = Random.Range(0, player.Length);

        if (isDual)
        {
            Debug.Log("trigger dual");
            player[randP].transform.position = spawnpointB.transform.position;
        }
    }
}
