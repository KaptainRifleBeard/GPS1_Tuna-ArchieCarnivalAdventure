using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    public Transform target;
    public GameObject[] players;
    public bool isKamikaze;

    public float enemySpeed;
    public float attackRadius;
    private float distance;
    public bool isFacingRight;
    protected float angle;
    protected Vector3 direction;

    void checkDistance()
    {
        if (Vector2.Distance(transform.position, target.position) < attackRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        }
        else
        {

            if (isFacingRight)
            {
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.Translate(2 * enemySpeed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(1, 1);  //(1, 1) -> refer to enemy's scale in transform
            }
            else
            {
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                transform.Translate(-2 * enemySpeed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(-1, 1); //flip enemy
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
            Destroy(gameObject);
        }
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            distance = Vector2.Distance(this.transform.position, players[i].transform.position);

            if (distance < attackRadius)
            {
                target = players[i].transform;
                attackRadius = distance;
            }
        }

    }
    void kamikaze()
    {
        if (Vector3.Distance(target.position, transform.position) < attackRadius)
        {
            enemySpeed = 6;
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

        }
    }

    void Update()
    {
        if (target != null)
        {
            checkDistance();
            if(isKamikaze)
            {
                kamikaze();
            }

            

        }
    }
}
