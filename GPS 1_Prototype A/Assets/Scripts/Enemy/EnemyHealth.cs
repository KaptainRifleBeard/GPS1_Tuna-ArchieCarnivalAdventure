using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] playerBullet;
    public int health;

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health = health - 2;    //later change it to player bullet damage

            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
