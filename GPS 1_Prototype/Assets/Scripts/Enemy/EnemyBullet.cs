using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
{
    public bool isKnockback;
    public float speed;

    private Transform player;
    private Vector2 target;

    public Rigidbody2D bullet;


    void Start()
    {
        //player = GameObject.FindWithTag("Player").transform;
        //target = new Vector2(player.position.x, player.position.y);
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

    //void Update()
    //{
    //    if (player != null)
    //    {
    //        Rigidbody2D enemyBulletRB = bullet.GetComponent<Rigidbody2D>();
    //        enemyBulletRB.AddForce(gameObject.transform.position * speed, ForceMode2D.Impulse);

    //        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    //        //Destroy(gameObject, 1f);

    //        //if (transform.position.x == target.x && transform.position.y == target.y)
    //        //{
    //        //    Destroy(gameObject);
    //        //}
    //    }


    //}

}
