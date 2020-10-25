using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    protected Vector3 direction;
    protected Rigidbody2D rb;

    public Transform target;

    protected float angle;
    public bool isFacingRight;
    public float enemySpeed;
    public float followRadius = 5f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
    }

    void turnDir()
    {
        if (isFacingRight)
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.Translate(2 * enemySpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(3f, 3f);  //(1, 1) -> refer to enemy's scale in transform
        }
        else
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.Translate(-2 * enemySpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-3f, 3f); //flip enemy
        }
    }

    void Update()
    {
        if(target != null)
        {
            if (GetComponent<BossAttack>().lineOfSight.enabled == true)
            {
                transform.position = this.transform.position;
                Debug.Log("boss stop");
            }
            if (GetComponent<BossAttack>().isLaser == true)
            {
                transform.position = this.transform.position;
                Debug.Log("boss stop");
            }
            if (GetComponent<BossAttack>().bossMove == true)
            {
                //To rotate the enemy facing the player
                rb.AddForce(target.position - transform.position, ForceMode2D.Impulse);
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                turnDir();
            }



        }

    }
}
