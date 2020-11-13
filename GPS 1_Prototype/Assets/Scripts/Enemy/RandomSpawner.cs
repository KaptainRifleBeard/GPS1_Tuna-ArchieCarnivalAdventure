using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject barrier;

    public GameObject blockExit;
    private int numbersEnemy;
    public int newNumEnemy;

    [SerializeField]public bool isSpawn = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            isSpawn = true;
            blockExit.SetActive(true);
        }
            
    }

    void Start()
    {
        numbersEnemy = Random.Range(4, 6);
        newNumEnemy = numbersEnemy;
    }

    void Update()
    {
        if (isSpawn)
        {   
            Debug.Log("enemy is spawn = true");
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSP = Random.Range(0, spawnPoints.Length);

            if (newNumEnemy > 0)
            {
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSP].position, transform.rotation);
                newNumEnemy--;
            }

            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {
                barrier.SetActive(false);
                blockExit.SetActive(false);
            }
        }

        if (WinLoseScreen.isRetryLevel == true && healthVisual.p1IsDead == true)
        {
            numbersEnemy = Random.Range(3, 6);
            Debug.Log("enemy is spawn = false");
            blockExit.SetActive(false);
            
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //foreach (GameObject enemy in enemies)
            //{
            //    GameObject.Destroy(enemy);
            //}
        }

    }

}
