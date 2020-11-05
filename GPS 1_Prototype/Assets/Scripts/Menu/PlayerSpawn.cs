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
    [HideInInspector] public int randPlayer1 = 0;
    [HideInInspector] public int randPlayer2 = 0;

    public void Start()
    {
        randPlayer1 = Random.Range(0, player1.Length);
        randPlayer2 = Random.Range(0, player2.Length);

        player1 = GameObject.FindGameObjectsWithTag("Player");
        player2 = GameObject.FindGameObjectsWithTag("Player2");

        if (getIsDual())
        {
            Debug.Log("trigger dual");
            player1[randPlayer1].transform.position = spawnpoint.transform.position;
            player2[randPlayer2].transform.position = spawnpoint.transform.position;
        }
        else
        {
            player1[0].transform.position = spawnpoint.transform.position;
        }
    }
}
