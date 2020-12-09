﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public static bool p1IsDead = false;
    public GameObject loseScreen;

    private int maxHeartAmount = 3;
    public int startHeart = 3;

    public int currentHealth;
    private int maxHealth;
    private int healthPerHeart = 2;

    public Image[] healthImage;
    public Sprite[] healthSprite;
    void Start()
    {
        currentHealth = startHeart * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        checkHealthAmount();
    }

    void checkHealthAmount()
    {
        for(int i = 0; i < maxHeartAmount; i++)
        {
            if(startHeart <= i)
            {
                healthImage[i].enabled = false;
            }
            else
            {
                healthImage[i].enabled = true;
            }
        }
        UpdateHeart();
    }

    void UpdateHeart()
    {
        bool empty = false;
        int i = 0;

        foreach(Image image in healthImage)
        {
            if(empty)
            {
                image.sprite = healthSprite[0];
            }
            else
            {
                i++;
                if(currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprite[healthSprite.Length - 1];
                }
                else
                {
                    int currHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int heartPerImage = healthPerHeart / (healthSprite.Length - 1);
                    int imageIndex = currHealth / heartPerImage;
                    image.sprite = healthSprite[imageIndex];
                    empty = true;       
                }
            }
        }
    }
                    
    public void takeDamage(int amount)
    {
        Debug.Log("take damage" + amount);
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startHeart * healthPerHeart);
        UpdateHeart();
    }

    public void healHealth(int amount)
    {
        currentHealth += amount;
        startHeart = Mathf.Clamp(startHeart, 0, maxHealth);
        checkHealthAmount();

    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

            Debug.Log("Dead!");
            p1IsDead = true;
            if (SelectPlayMode.isDual == true)
            {
                foreach (GameObject p in player)
                {
                    if (p.layer == 9)
                    {
                        Destroy(p);
                        if (p1IsDead == true && HeartSystemB.p2IsDead == true)
                        {
                            loseScreen.SetActive(true);
                            if (WinLoseScreen.isRetryLevel == true)
                            {
                                p1IsDead = false;
                            }
                        }
                    }

                }

            }
            else
            {
                if (p1IsDead)
                {
                    loseScreen.SetActive(true);
                    if (WinLoseScreen.isRetryLevel == true)
                    {
                        p1IsDead = false;
                    }
                }
            }
            Debug.Log("Player die");
        }
    }


}
