using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    GameObject target = null;
    public GameObject[] players;
    public bool isKamikaze;

    public float enemySpeed;
    public float attackRadius;
    private float distance;
    public bool isFacingRight;
    protected float angle;
    protected Vector3 direction;

    public Animator animator;
    void checkDistance()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < attackRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
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
        //players = GameObject.FindGameObjectsWithTag("Player");

        float distanceToClosestPlayer = Mathf.Infinity;
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

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
    void kamikaze()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < attackRadius)
        {
            enemySpeed = 6;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);

        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            checkDistance();
            if(isKamikaze)
            {
                kamikaze();
            }



        }
    }
}
