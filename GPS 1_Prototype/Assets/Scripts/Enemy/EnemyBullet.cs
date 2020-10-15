using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public bool isKnockback;
    public float speed;

    Player player;
    private Vector2 dir;

    public Rigidbody2D rb;


    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        dir = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(dir.x, dir.y);

        Destroy(gameObject, 3f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Tilemap") || other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }

        if (isKnockback)
        {
            if (other.gameObject.CompareTag("Player"))
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
