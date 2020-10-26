using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public GameObject bossBullet;
    public bool isBossBullet = false;

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

    }

    public void heal(int healAmount)
    {
        healthVisual.HealthSystem.addHealth(healAmount);
    }
}
