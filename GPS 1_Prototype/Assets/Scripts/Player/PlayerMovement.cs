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
    GameObject ballClone;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(myShoot))
        {

            if (rend.sprite == up)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y + 0.5f), bulletSpawnPOS.rotation);
            }
            else if (rend.sprite == down)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y - 0.5f), bulletSpawnPOS.rotation);
       
            }
            else
            {
                ballClone = Instantiate(bulletPrefab, bulletSpawnPOS.position, bulletSpawnPOS.rotation);
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
                //playerVisual.rotation = Quaternion.Euler(180, 0, 180); 
                rend.sprite = left;

            }
            if (Input.GetKey(myright))
            {
                rb.AddForce(Vector3.right * force, ForceMode2D.Impulse);
                //playerVisual.rotation = Quaternion.Euler(0, 0, 0);
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
    }

}


