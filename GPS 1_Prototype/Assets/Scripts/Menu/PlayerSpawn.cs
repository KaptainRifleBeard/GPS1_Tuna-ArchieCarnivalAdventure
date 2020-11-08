using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpoint;

    public int randPlayer = 0;
    public int currPlayer = 0;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    void Start()
    {
        randPlayer = Random.Range(0, player.Length);
        currPlayer = randPlayer;

        Debug.Log("randplayer = " + randPlayer);
        Debug.Log("currplayer = " + currPlayer);

        player[randPlayer].transform.position = spawnpoint.transform.position;


        //if (currPlayer == 0)
        //{
        //    WeaponIcon.image.sprite = dart_icon;

        //}
        //if (currPlayer == 1)
        //{

        //    WeaponIcon.image.sprite = uni_icon;

        //}
    }

    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        if (healthVisual.p1IsDead == true && y == 4)
        {
            player[randPlayer].transform.position = spawnpoint.transform.position;

        }
    }
}
