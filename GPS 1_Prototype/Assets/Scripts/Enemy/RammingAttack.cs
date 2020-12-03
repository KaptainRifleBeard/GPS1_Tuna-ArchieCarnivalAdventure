using System.Collections;
using System.Collections.Generic;
    
using UnityEngine;

public class RammingAttack : MonoBehaviour
{
    GameObject target = null;
    public GameObject[] players;
    public Animator animator;

    private float distance;

    public float enemySpeed;

    public bool isRamming;
    public bool RammingDelay;
    public bool isFacingRight;

    public float followRadius;
    public float stopRadius;
    public float rammingRadius;

    //raycast
     

    void checkDistance()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < followRadius)
        {
            //addforce
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
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
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
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
        isRamming = true;
    }




    void Start()
    {
        RammingDelay = false;
        isRamming = true;

        players = GameObject.FindGameObjectsWithTag("Player");

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


    void Update()
    {
        if (target != null)
        {

            checkDistance();

            if (RammingDelay == false && isRamming == true)
            {

                enemySpeed = 4;
                ramming();
            }
            else if (RammingDelay == true && isRamming == false)
            {

                enemySpeed = 0;
                StartCoroutine(AttackDelay());
                GetComponent<TouchEnemyGetDamage>().damageAmount = 0;
            }

            if(isRamming)
            {
                animator.SetBool("toRam", true);
            }
            else
            {
                animator.SetBool("toRam", false);
            }

        }
    }
}

