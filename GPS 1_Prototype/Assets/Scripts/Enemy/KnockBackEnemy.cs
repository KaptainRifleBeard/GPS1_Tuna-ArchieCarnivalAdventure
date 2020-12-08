﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEnemy : MonoBehaviour
{
    GameObject target = null;
    public Transform shootPos;
    public GameObject[] players;

    public float enemySpeed;
    public float retreatRadius;
    public float stopRadius;
    public float attackRadius;

    public GameObject bullet;

    public float startTimeBtwShoot;
    private float timeBtwShoot;
    
    public float distance;

    public Animator animator;


    void checkDistance()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > stopRadius)
        {
            animator.SetBool("isWalk", true);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > retreatRadius &&
                 Vector2.Distance(transform.position, target.transform.position) < stopRadius)
        {
            animator.SetBool("isWalk", false);
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatRadius)
        {
            animator.SetBool("isWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, -enemySpeed * 2 * Time.deltaTime);
        }

    }





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap") || collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("Stage"))
        {
            transform.position = this.transform.position;
        }
    }





    void Start()
    {
        timeBtwShoot = startTimeBtwShoot;

        players = GameObject.FindGameObjectsWithTag("Player");


        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject currentPlayer in allPlayers)
        {
            float distanceToEnemy = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                target = currentPlayer;
            }
        }

    }
    public Vector2 dir;

    void Update()
    {
        if (target != null)
        {
            //Vector3 dir = target.transform.position - transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            checkDistance();

            if (Vector2.Distance(transform.position, target.transform.position) < stopRadius)
            {
                transform.position = this.transform.position;
                if (timeBtwShoot <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("CottonShoot");

                    GameObject b =Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
                    b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;

                    timeBtwShoot = startTimeBtwShoot;  //shoot delay
                }
                else
                {
                    timeBtwShoot -= Time.deltaTime;
                }
            }
            

        }
    }
}
