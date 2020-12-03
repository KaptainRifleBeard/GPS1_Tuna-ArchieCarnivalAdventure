using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    public static Image image;

    public Sprite dart_icon, uni_icon, cheese_icon, water_icon;

        
    void Start()
    {
        image = GetComponent<Image>();

        if(PlayerSpawn.playerRespawn.name == "Tuna_Right_DartSheet")
        {
            image.sprite = dart_icon;
        }
        else if (PlayerSpawn.playerRespawn.name == "Tuna_Right_Unicorn")
        {
            image.sprite = uni_icon;
        }
        else if (PlayerSpawn.playerRespawn.name == "Tuna_Right_Cheese")
        {
            image.sprite = cheese_icon;
        }

    }
}
