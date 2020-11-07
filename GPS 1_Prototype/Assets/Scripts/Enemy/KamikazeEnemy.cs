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
    private enum State { idle, walking, hurt }
    private State state = State.idle;

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
                animator.SetBool("isWalk", true);

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
            animator.SetInteger("state", (int)state);
            checkDistance();
            if(isKamikaze)
            {
                kamikaze();
            }
            else
            {
                animator.SetBool("isWalk", false);
            }



        }
    }
}
