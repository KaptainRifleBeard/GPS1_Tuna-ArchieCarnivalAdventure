    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public bool isKnockback;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2") || 
            other.gameObject.CompareTag("Tilemap") || other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }

        if (isKnockback)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
            {
                Destroy(gameObject);

                var player = other.GetComponent<PlayerMovement>();
                player.knockbackCount = player.knockbackLength;

                if(other.transform.position.x < transform.position.x)
                {
                    player.isKnockbackRight = true;
                }
                else
                {
                    player.isKnockbackRight = false;

                }
            }
        }

    }

}
