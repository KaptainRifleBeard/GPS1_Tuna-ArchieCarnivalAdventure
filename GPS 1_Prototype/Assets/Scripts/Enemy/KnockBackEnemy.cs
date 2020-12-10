using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEnemy : MonoBehaviour
{
    GameObject target = null;
    public Transform shootPos;
    public GameObject[] players;

    public float enemySpeed;
    public float retreatRadius;
    public float stopRadius;
    public float attackRadius;

    public GameObject bullet;
    GameObject b;

    public float startTimeBtwShoot;
    private float timeBtwShoot;
    
    public float distance;

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

        players = GameObject.FindGameObjectsWithTag("Player");


        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject currentPlayer in allPlayers)
        {
            float distanceToEnemy = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                target = currentPlayer;
            }
        }

    }

    void shoot()
    {
        relativePoint = transform.InverseTransformPoint(target.transform.position);
        if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            //left
            b = Instantiate(bullet, new Vector2(shootPos.position.x - .5f, shootPos.position.y), shootPos.rotation);
            b.transform.right = -transform.right.normalized;
            b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;
        }
        if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            //right
            b = Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
            b.transform.right = transform.right.normalized;
            b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;

        }
        if (relativePoint.y > 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
        {
            //down
            b = Instantiate(bullet, new Vector2(shootPos.position.x - .2f, shootPos.position.y), shootPos.rotation);
            b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;

        }
        if (relativePoint.y < 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
        {
            //up
            b = Instantiate(bullet, new Vector2(shootPos.position.x - .2f, shootPos.position.y + .1f), shootPos.rotation);
            b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;
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

            if (Vector2.Distance(transform.position, target.transform.position) < stopRadius)
            {
                transform.position = this.transform.position;
                if (timeBtwShoot <= 0)
                {
                    FindObjectOfType<AudioManager>().Play("CottonShoot");
                    shoot();


                    //b =Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
                    //b.GetComponent<Rigidbody2D>().velocity = (target.transform.position - b.transform.position).normalized * 10;

               
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
