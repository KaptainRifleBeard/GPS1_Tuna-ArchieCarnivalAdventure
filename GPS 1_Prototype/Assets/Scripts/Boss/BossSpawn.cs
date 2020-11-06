using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public Transform spawnPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(boss, spawnPoints.position, Quaternion.identity);   
            Destroy(gameObject);
        }
    }
  
}
