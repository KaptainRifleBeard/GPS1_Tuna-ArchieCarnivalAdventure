﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public static healthSystemB HealthSystem;

    public GameObject bossBullet;
    public bool isBossBullet = false;
    public SpriteRenderer SetSpriteColor;
    IEnumerator getDamageVFX()
    {
        for (int n = 0; n < 2; n++)
        {
            SetSpriteColor.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            SetSpriteColor.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);  //the player wont destroy after load to next level
    }

    public void DamageKnockback(Vector3 kbDir, float kbDis, int damageAmount)
    {
        transform.position += kbDir * kbDis;
        healthVisualB.HealthSystem.Damage(damageAmount);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BossBullet"))
        {
            isBossBullet = true;
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            StartCoroutine(getDamageVFX());
        }
    }

    public void heal(int healAmount)
    {
        healthVisualB.HealthSystem.addHealth(healAmount);
    }
}
