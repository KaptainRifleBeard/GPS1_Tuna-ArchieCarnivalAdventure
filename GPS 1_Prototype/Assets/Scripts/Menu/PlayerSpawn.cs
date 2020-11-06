using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpoint;
    public int randPlayer1 = 0; 
    public int randPlayer2 = 2  ;

    public void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        randPlayer1 = Random.Range(0, 1);
        randPlayer2 = Random.Range(2, 3);


        if (getIsDual())
        {
            Debug.Log("trigger dual");
            player[randPlayer1].transform.position = spawnpoint.transform.position;
            player[randPlayer2].transform.position = spawnpoint.transform.position;
        }
        else
        {

            player[randPlayer1].transform.position = spawnpoint.transform.position;
        }
    }
}
