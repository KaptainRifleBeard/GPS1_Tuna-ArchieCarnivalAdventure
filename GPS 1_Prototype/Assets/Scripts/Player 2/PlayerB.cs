using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public GameObject bossBullet;
    public bool isBossBullet = false;
    public GameObject winScreen;

    void Start()
    {
        DontDestroyOnLoad(gameObject);  //the player wont destroy after load to next level
    }

    private void Update()
    {
        //if (healthVisualB.p2IsDead == true)
        //{
        //    Destroy(gameObject);
        //}
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
        if (other.gameObject.CompareTag("ToNextLevel"))
        {
            //winScreen.SetActive(true);

        }
    }

    public void heal(int healAmount)
    {
        healthVisual.HealthSystem.addHealth(healAmount);
    }
}
