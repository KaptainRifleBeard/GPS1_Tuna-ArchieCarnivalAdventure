using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon2 : MonoBehaviour
{
    public static Image image;
    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;


    void Start()
    {
        image = GetComponent<Image>();

        //Player B weapon icon
        if (PlayerBSpawn.playerBRespawn.name == "Archie_Right_Nacho Cheese")
        {
            image.sprite = cheese_icon;
        }
        else if (PlayerBSpawn.playerBRespawn.name == "Archie_Right_Unicorn")
        {
            image.sprite = uni_icon;
        }
        else if (PlayerBSpawn.playerBRespawn.name == "Archie_Right_Dart")
        {
            image.sprite = dart_icon;
        }
    }
}