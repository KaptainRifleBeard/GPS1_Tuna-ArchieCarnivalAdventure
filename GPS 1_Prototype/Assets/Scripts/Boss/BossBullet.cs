﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //private GameObject player = null;

    public bool isDrumBullet = false;
    public int health;
    public Rigidbody2D rb;


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

    }

    void Start()
    {
        //player = GameObject.FindWithTag("Player").transform;
        // target = new Vector2(player.position.x, player.position.y);
        Destroy(gameObject, 3f);
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (BossAttack.target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, BossAttack.target.transform.position, 6 * Time.deltaTime);

        }

    }
}





