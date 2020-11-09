using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBSpawn : SelectPlayMode
{
    public GameObject[] player;
    public GameObject spawnpointB;

    public int randP = 0;
    public int cPlayer = 0;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    public void Start()
    {
        randP = Random.Range(0, player.Length);
        cPlayer = randP;

        if (isDual)
        {       
            Debug.Log("trigger dual");
            player[randP].transform.position = spawnpointB.transform.position;

            //if (cPlayer == 0)
            //{
            //    WeaponIcon2.image2.sprite = cheese_icon;

            //}
            //else if (cPlayer == 1)
            //{
            //    WeaponIcon2.image2.sprite = water_icon;

            //}
        }
        
    }

    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        //if (healthVisualB.p2IsDead == true && y == 4)
        //{
        //    player[randP].transform.position = spawnpointB.transform.position;

        //}
    }
}
