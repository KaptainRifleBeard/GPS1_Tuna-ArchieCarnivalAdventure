﻿using System.Collections;
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
