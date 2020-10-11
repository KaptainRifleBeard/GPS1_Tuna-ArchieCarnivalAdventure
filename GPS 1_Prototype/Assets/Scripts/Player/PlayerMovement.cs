using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    public KeyCode myup;
    public KeyCode mydown;
    public KeyCode myleft;
    public KeyCode myright;
    public KeyCode myShoot;

    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPOS;
    public Transform playerVisual;

    //player knockback
    public float knockback;
    public float knockbackCount;
    public float knockbackLength;
    public bool isKnockbackRight;


    //private float x;
    //private float y;

    //private bool m_FacingRight;

    //public void Flip()
    //{
    //    m_FacingRight = !m_FacingRight;

    //    rb.transform.Rotate(0f, 180f, 0f);
    //}

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        //if (Input.GetKey(myleft))
        //{
        //    rb.velocity = new Vector2(-speed, rb.velocity.y);
        //}

        
        //if (Input.GetKeyDown(myShoot))
        //{

        //    fire();
        //}



        if (Input.GetKeyDown(myShoot))
        {
            GameObject ballClone = Instantiate(bulletPrefab, bulletSpawnPOS.position, bulletSpawnPOS.rotation);
        }


        //if not knockback, player able to move
        if (knockbackCount <= 0)
        {
            if (Input.GetKey(myleft))
            {
                //transform.Translate(Vector3.left * speed);
                rb.AddForce(Vector3.left * force, ForceMode2D.Impulse);
                //rb.AddForce(Vector3.left * force);

                playerVisual.rotation = Quaternion.Euler(180, 0, 180);
            }
            if (Input.GetKey(myright))
            {
                //transform.Translate(Vector3.right * speed);
                rb.AddForce(Vector3.right * force, ForceMode2D.Impulse);
                //rb.AddForce(Vector3.right * force);

                playerVisual.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(myup))
            {
                //transform.Translate(Vector3.up * speed);
                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                //rb.AddForce(Vector3.up * force);

                playerVisual.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (Input.GetKey(mydown))
            {
                //transform.Translate(Vector3.down * speed);
                rb.AddForce(Vector3.down * force, ForceMode2D.Impulse);
                //rb.AddForce(Vector3.down * force);

                playerVisual.rotation = Quaternion.Euler(0, 0, -90);
            }

        }
        else
        {
            if (isKnockbackRight)
            {
                rb.velocity = new Vector2(-knockback, knockback);
            }

            if (!isKnockbackRight)
            {
                rb.velocity = new Vector2(knockback, knockback);

            }
            knockbackCount -= Time.deltaTime;
        }




        //if (rb.velocity.x < 0) // if we move to the left
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        //else if (rb.velocity.x > 0)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //if (rb.velocity.x < 0 && m_FacingRight) // if we move to the left
        //{
        //    // transform.localScale = new Vector3(-1, 1, 1);

        //    Flip();
        //}
        //else if (rb.velocity.x > 0 && !m_FacingRight)
        //{
        //    // transform.localScale = new Vector3(1, 1, 1);

        //    Flip();
        //}




    }
}

//    void fire()
//    {
//        bulletSpawnPOS = transform.position;
//        GameObject new_bullet = Instantiate(bulletPrefab, bulletSpawnPOS, Quaternion.identity);
//        //rotate the bullet as the gameobject
//        new_bullet.transform.right = transform.right.normalized;
//        //    bulletSpawnPOS = transform.position;

//        //    GameObject new_bullet = Instantiate(bulletPrefab, bulletSpawnPOS, Quaternion.identity);

//        //    Quaternion direction = transform.rotation;
//        //    var radians = direction.z * Mathf.Deg2Rad;

//        //    x = Mathf.Cos(radians);
//        //    y = Mathf.Sin(radians);

//        //    new_bullet.GetComponent<bullet_flying>().velX = x;
//        //    new_bullet.GetComponent<bullet_flying>().velY = y;


//    }

    
//}

    //public float moveSpeed;
    //private Rigidbody2D rb;
    //private Vector2 moveDirection;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = this.GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    ProcessInputs();
    //}

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //void ProcessInputs()
    //{
    //    float moveX = Input.GetAxisRaw("Horizontal");
    //    float moveY = Input.GetAxisRaw("Vertical");

    //    moveDirection = new Vector2(moveX, moveY).normalized;
    //}

    //void Move()
    //{
    //    rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    //}




