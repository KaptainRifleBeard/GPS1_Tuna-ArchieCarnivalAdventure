using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player1;
    public GameObject[] player2;
    public GameObject spawnpoint;

    void Start()
    {
        int randPlayer1 = Random.Range(0, player1.Length);
        int randPlayer2 = Random.Range(0, player2.Length);

        if (getIsDual())
        {
            Debug.Log("trigger dual");
            player1[randPlayer1].transform.position = spawnpoint.transform.position;
            player2[randPlayer2].transform.position = spawnpoint.transform.position;
        }
        else
        {
            player1[randPlayer1].transform.position = spawnpoint.transform.position;
        }
    }
}
