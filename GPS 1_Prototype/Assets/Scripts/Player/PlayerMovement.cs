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
    public int direction;
    public Animator animator;

    //private AudioManager audio;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //audio = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(myShoot))
        {
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
            //audio.Play("PlayerShoot");
            //Debug.Log("ballClone");

            
            Debug.Log("isShoot");
            if (direction == 2)          
            {
                Debug.Log("ballClone");

                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y + 1f), bulletSpawnPOS.rotation);
                ballClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

            }
            else if (direction == 3)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x, bulletSpawnPOS.position.y - 1.5f), bulletSpawnPOS.rotation);
                ballClone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));

            }
            else if (direction == 0)
            {
                ballClone = Instantiate(bulletPrefab, new Vector2(bulletSpawnPOS.position.x - .5f, bulletSpawnPOS.position.y), bulletSpawnPOS.rotation);
                ballClone.transform.right = -transform.right.normalized;
            }
            else if (direction == 1)
            {
                Debug.Log("ballClone");
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
                //Animation -> BlendTree
                if(Vector3.left != Vector3.zero)
                {
                    direction = 0;

                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                }

                animator.SetFloat("Speed", force);

                rb.AddForce(Vector3.left * force, ForceMode2D.Impulse);
                //rend.sprite = left;
                
            }
            if (Input.GetKey(myright))
            {
                //Animation -> BlendTree
                if (Vector3.right != Vector3.zero)
                {
                    direction = 1;

                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                }
                animator.SetFloat("Speed", force);

                rb.AddForce(Vector3.right * force, ForceMode2D.Impulse);
                //rend.sprite = right;
            }
            if (Input.GetKey(myup))
            {
                //Animation -> BlendTree
                if (Vector3.up != Vector3.zero)
                {
                    direction = 2;

                    animator.SetFloat("Vertical", 1);
                    animator.SetFloat("Horizontal", 0);
                }
                animator.SetFloat("Speed", force);

                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                //rend.sprite = up;

            }
            if (Input.GetKey(mydown))
            {
                //Animation -> BlendTree
                if (Vector3.down != Vector3.zero)
                {
                    direction = 3;

                    animator.SetFloat("Vertical", -1);
                    animator.SetFloat("Horizontal", 0);
                }
                animator.SetFloat("Speed", force);

                rb.AddForce(Vector3.down * force, ForceMode2D.Impulse);
                //rend.sprite = down;
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


