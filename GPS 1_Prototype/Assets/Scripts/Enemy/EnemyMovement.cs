using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Vector3 direction;
    public Transform target;
    public Transform barrier;
    protected Rigidbody2D rb;
    protected float angle;

    //public float knockback;
    //public float knockbackCount;
    //public float knockbackLength;
    //public bool isKnockbackRight;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()  
    {
    
        //To rotate the enemy facing the player
        rb.AddForce(target.position - transform.position, ForceMode2D.Impulse);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    }

}
