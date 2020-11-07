using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
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
    GameObject ballClone;

    public Transform bulletSpawnPOS;
    public Transform playerVisual;

    //player knockback
    public float knockback;
    public float knockbackCount;
    public float knockbackLength;
    public bool isKnockbackRight;

    //Changing  sprite
    public SpriteRenderer rend;
    public Sprite up, down, left, right;
    private Animator anim;
    private Vector2 lastMove;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(myShoot))  
        {
            if (rend.sprite == up)          
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y + 1f), bulletSpawnPOS.rotation);
                ballClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

            }
            else if (rend.sprite == down)   
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y - 1f), bulletSpawnPOS.rotation);
                ballClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));

            }
            else if (rend.sprite == left)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x - .5f, bulletSpawnPOS.position.y), bulletSpawnPOS.rotation);
                ballClone.transform.right = -transform.right.normalized;
            }
            else if(rend.sprite == right)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x + .5f, bulletSpawnPOS.position.y), bulletSpawnPOS.rotation);

            }

        }

    }

    private void FixedUpdate()
    {
        
        //if not knockback, player able to move
        if (knockbackCount <= 0)
        {
            if (Input.GetKey(myleft))
            {
                rb.AddForce(Vector3.left * force, ForceMode2D.Impulse);
                rend.sprite = left;
               
            }
            if (Input.GetKey(myright))
            {
                rb.AddForce(Vector3.right * force, ForceMode2D.Impulse);
                rend.sprite = right;
               
            }
            if (Input.GetKey(myup))
            {
                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                rend.sprite = up;
              
            }
            if (Input.GetKey(mydown))
            {
                rb.AddForce(Vector3.down * force, ForceMode2D.Impulse);
                rend.sprite = down;
              
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
        anim.SetFloat("moveX", rb.velocity.x);
        anim.SetFloat("moveY", rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        

        //if (Input.anyKey == true)
        //{
        //    anim.SetFloat("moveX", rb.velocity.x);
        //    anim.SetFloat("moveY", rb.velocity.y);
        //}
        //else
        //{
        //    anim.SetFloat("lastMoveX", rb.velocity.x);
        //    anim.SetFloat("lastMoveY", rb.velocity.y);
        //}

        //if (force == 0)
        //{
        //    anim.SetFloat("lastMoveX", rb.velocity.x);
        //    anim.SetFloat("lastMoveY", rb.velocity.y);

        //}
    }

}


