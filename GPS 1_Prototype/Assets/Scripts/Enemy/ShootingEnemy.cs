using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject[] players;
    GameObject target = null;
    public Transform shootPos;

    public float enemySpeed;
    public float retreatRadius;
    public float stopRadius;
    public float attackRadius;

    public GameObject bullet;

    public float startTimeBtwShoot;
    private float timeBtwShoot;

    public Animator animator;
    public Vector2 relativePoint;

    void checkDistance()
    {

        if (Vector2.Distance(transform.position, target.transform.position) > stopRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > retreatRadius && 
                 Vector2.Distance(transform.position, target.transform.position) < stopRadius)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < retreatRadius)
        {
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


    }

    void Update()
    {
        if (target != null)
        {
            //Vector3 dir = target.transform.position - transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            checkDistance();
            if (Vector2.Distance(target.transform.position, transform.position) < attackRadius)
            {
                if (timeBtwShoot <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("CorkGunShoot");

                    GameObject b = Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
                    b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;
                    timeBtwShoot = startTimeBtwShoot;  //shoot delay

                }
                else
                {
                    timeBtwShoot -= Time.deltaTime;
                }

                
            }

            relativePoint = transform.InverseTransformPoint(target.transform.position);
            if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                //rend.sprite = left;
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Horizontal", -1);
            }
            if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
            {
                //rend.sprite = right;
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Horizontal", 1);
            }
            if (relativePoint.y > 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
            {
                //rend.sprite = down;

                animator.SetFloat("Vertical", 1);
                animator.SetFloat("Horizontal", 0);

            }
            if (relativePoint.y < 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
            {
                //rend.sprite = up;
                animator.SetFloat("Vertical", -1);
                animator.SetFloat("Horizontal", 0);

            }

        }
    }
}

