using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingAttack : EnemyMovement
{
    public float enemySpeed;

    public bool isStop;
    public bool isRamming;
    public bool isFacingRight;

    public float followRadius;
    public float stopRadius;
    public float rammingRadius;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void checkDistance()
    {

        if (Vector2.Distance(transform.position, target.position) > stopRadius)
        {
            if (Vector3.Distance(target.position, transform.position) <= followRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
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
    }

    void ramming()
    {
        if (Vector3.Distance(target.position, transform.position) <= rammingRadius)
        {
            enemySpeed = 5;
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
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

            if (isRamming == false)
            {
                enemySpeed = 1;
                StartCoroutine(ChangeRammingBool());
            }
        }
    }

    public IEnumerator ChangeRammingBool()
    {
        yield return new WaitForSeconds(3f);
        isRamming = true;
    }


    void Update()
    {
        if (target != null)
        {
            checkDistance();

            if (isRamming == true)
            {
                ramming();

            }
            
        }
    }
}

