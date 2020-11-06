using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 target;

    private Transform player;

    public bool isDrumBullet = false;
    public int health;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Tilemap") || other.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 5;  //change it later

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        //if (other.gameObject.CompareTag("Stage"))
        //{
        //    transform.position = new Vector3(1f, 1f, 3f);
        //}

    }

    void Start()
    {
        //player = GameObject.FindWithTag("Player").transform;
       // target = new Vector2(player.position.x, player.position.y);
        Destroy(gameObject, 3f);

    }

    void Update()
    {
        //if(player != null)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //    if (transform.position.x == target.x && transform.position.y == target.y)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        
     
    }
}
