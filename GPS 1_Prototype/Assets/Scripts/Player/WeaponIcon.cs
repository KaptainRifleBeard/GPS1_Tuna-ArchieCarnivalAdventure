using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    public Image image;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

    //public GameObject uni;
    //public GameObject cheese;
    //public GameObject water;


    void Start()
    {
        Debug.Log("CURRENT icon num: " + PlayerSpawn.currPlayer);


        if (PlayerSpawn.currPlayer == 0)
        {

            image.sprite = dart_icon;

        }
        else if (PlayerSpawn.currPlayer == 1)
        {
            image.sprite = uni_icon;

        }



        //if (PlayerSpawn.randP == 0)
        //{
        //    image.sprite = cheese_icon;
        //}
        //if (PlayerSpawn.randP == 1)
        //{
        //    image.sprite = water_icon;
        //}
    }
}
