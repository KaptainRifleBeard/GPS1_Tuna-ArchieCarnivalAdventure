using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : SelectPlayMode
{
    public GameObject storePoint;
    public GameObject[] player;
    public GameObject spawnpoint;

    public int randPlayer = 0;
    static int currPlayer;



    public GameObject dart;
    public GameObject uni;
    public GameObject cheese;
    public GameObject water;


    void Start()
    {
        if (healthVisual.p1IsDead == true || healthVisualB.p2IsDead == true)
        {
            Instantiate(dart, storePoint.transform.position, Quaternion.identity);
            Instantiate(uni, storePoint.transform.position, Quaternion.identity);
            Instantiate(cheese, storePoint.transform.position, Quaternion.identity);
            Instantiate(water, storePoint.transform.position, Quaternion.identity);

        }



        
            

    }
    void FixedUpdate()
    {
        /*
        int y = SceneManager.GetActiveScene().buildIndex;


        if (healthVisual.p1IsDead == true && y == 4)
        {
            randPlayer = Random.Range(0, player.Length);
            currPlayer = randPlayer;


            player[randPlayer].transform.position = spawnpoint.transform.position;

            if (isDual == true)
            {
                int randP = Random.Range(0, player.Length);
                player[randP].transform.position = spawnpoint.transform.position;
            }
        }
        */
    }

}
