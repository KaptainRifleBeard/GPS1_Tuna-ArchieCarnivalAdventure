using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform target;
    public GameObject[] players;

    public float enemySpeed;
    public float retreatRadius;
    public float stopRadius;
    public float attackRadius;

    private Rigidbody2D rb;
    public GameObject bullet;

    public float startTimeBtwShoot;
    private float timeBtwShoot;

    public bool isP1 = false;
    public bool isP2 = false;

    GameObject[] player1s;
    GameObject[] player2s;
    private float distance;
    void checkDistance()
    {
        
        if (Vector2.Distance(transform.position, target.position) > stopRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > retreatRadius && 
                 Vector2.Distance(transform.position, target.position) < stopRadius)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, -enemySpeed *2 * Time.deltaTime);
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
        rb = this.GetComponent<Rigidbody2D>();
        timeBtwShoot = startTimeBtwShoot;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            distance = Vector2.Distance(this.transform.position, players[i].transform.position);

            if (distance < retreatRadius)
            {
                target = players[i].transform;
                retreatRadius = distance;
            }
        }

    }

    void Update()
    {
        if (target != null)
        {
            checkDistance();
            if (Vector2.Distance(target.position, transform.position) < attackRadius)
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

