﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public float bulletSpeed;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public float attackRadius;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoot = startTimeBtwShoot;

    }

    void Update()
    {


        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < attackRadius)
            {
                if (timeBtwShoot <= 0)
                {
                    Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
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