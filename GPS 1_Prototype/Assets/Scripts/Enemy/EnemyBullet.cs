using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public bool isKnockback;
    public float speed;

    public Player player;
    public PlayerB playerB;

    public Vector2 dir;

    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindObjectOfType<Player>();
        dir = (player.transform.position - transform.position).normalized * speed;

        playerB = GameObject.FindObjectOfType<PlayerB>();
        dir = (playerB.transform.position - transform.position).normalized * speed;

        rb.velocity = new Vector2(dir.x, dir.y);
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

    void Update()
    {
        

    }

}
