using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEnemy : MonoBehaviour
{
    public Transform target;
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
            transform.position = Vector3.MoveTowards(transform.position, target.position, -enemySpeed * 2 * Time.deltaTime);
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
    public Vector2 dir;

    void Update()
    {
        if (target != null)
        {

            checkDistance();

            if (Vector2.Distance(transform.position, target.position) < stopRadius)
            {
                transform.position = this.transform.position;
                if (timeBtwShoot <= 0)
                {
                    GameObject b =Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
                    b.GetComponent<Rigidbody2D>().velocity = (target.position - b.transform.position).normalized * 10;

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
