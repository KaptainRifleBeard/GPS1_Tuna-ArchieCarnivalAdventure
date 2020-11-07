using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    //public Transform target;
    public GameObject[] players;
    GameObject target = null;
    public Animator animator;


    public Transform shootPos;

    public float enemySpeed;
    public float retreatRadius;
    public float stopRadius;
    public float attackRadius;

    public GameObject bullet;

    public float startTimeBtwShoot;
    private float timeBtwShoot;


    private float distance;
    SpriteRenderer up, down;

    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    void checkDistance()
    {

        if (Vector2.Distance(transform.position, target.transform.position) > stopRadius)
        {
            animator.SetBool("isAttack", true);

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > retreatRadius && 
                 Vector2.Distance(transform.position, target.transform.position) < stopRadius)
        {
            animator.SetBool("isAttack", false);

            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatRadius)
        {
            animator.SetBool("isAttack", false);

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

        //target = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");


        float distanceToClosestPlayer = Mathf.Infinity;
        GameObject[] allPlayers= GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                target = currentPlayer;
            }
        }


        //for (int i = 0; i < players.Length; i++)
        //{
        //    Debug.Log(players[i]);
        //    distance = Vector2.Distance(this.transform.position, players[i].transform.position);

        //    if (distance < retreatRadius)
        //    {
        //        target = players[i].transform;
        //        retreatRadius = distance;
        //    }
        //}



    }

    void Update()
    {
        if (target != null)
        {
            checkDistance();
            if (Vector2.Distance(target.transform.position, transform.position) < attackRadius)
            {
                if (timeBtwShoot <= 0)
                {
                    GameObject b = Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
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

