﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject barrier;
    public int numbersEnemy;

    public bool isSpawn = false;
    public float spawnDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSpawn = true;
        }
    }
    void Start()
    {
        numbersEnemy = Random.Range(3, 6);
    }

    void Update()
    {

        if (isSpawn)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            if (numbersEnemy > 0)
            {
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
                numbersEnemy--;
               

            }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {
                DestroyImmediate(barrier, true);
            }
        }
       

    }
}
