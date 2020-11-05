using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class RammingAttack : MonoBehaviour
{
    public Transform target;
    public GameObject[] players;
    private float distance;

    public float enemySpeed;

    public bool isRamming;
    public bool RammingDelay;
    public bool isFacingRight;

    public float followRadius;
    public float stopRadius;
    public float rammingRadius;

     

    void checkDistance()
    {
        if (Vector2.Distance(transform.position, target.position) <= followRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        }
    }

    void ramming()
    {
        if (isRamming == true)
        {
            GetComponent<TouchEnemyGetDamage>().damageAmount = 1;
            if (Vector3.Distance(target.transform.position, transform.position) <= rammingRadius)
            {
                enemySpeed = 8;
                transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
            }
        }
    }





    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap") || collision.gameObject.CompareTag("Barrier") || collision.gameObject.CompareTag("Stage"))
        {
            if (isFacingRight)
            {
                isFacingRight = false;
            }
            else
            {
                isFacingRight = true;
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isRamming = false;
            RammingDelay = true;
        }
    }




    public IEnumerator ChangeRammingBool()
    {
        yield return new WaitForSeconds(3f);
        isRamming = true;

    }
    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        RammingDelay = false;
        StartCoroutine(ChangeRammingBool());

    }
    public IEnumerator WhenStartSpawn()
    {
        yield return new WaitForSeconds(0.5f);
        checkDistance();
    }




    void Start()
    {
        RammingDelay = false;
        isRamming = true;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            distance = Vector2.Distance(this.transform.position, players[i].transform.position);

            if (distance < followRadius)
            {
                target = players[i].transform;
                followRadius = distance;
            }
        }
    }
    void Update()
    {
        if (target != null)
        {
            Debug.Log(Time.deltaTime);

            if (RammingDelay == false && isRamming == true)
            {
                StartCoroutine(WhenStartSpawn());
                ramming();
            }
            else if (RammingDelay == true && isRamming == false)
            {
                enemySpeed = 4;
                StartCoroutine(AttackDelay());
                GetComponent<TouchEnemyGetDamage>().damageAmount = 0;
            }

        }
    }
}

