    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject snowBallEffect;
    public float speed;
    public int damageAmount = 0;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        Destroy(gameObject, 3f);

    }       
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stage") || other.gameObject.CompareTag("RoomManager") || other.gameObject.CompareTag("RegionDetectPlayer")
            || other.gameObject.CompareTag("RoomBoundary") || other.gameObject.CompareTag("Ticket") || other.gameObject.CompareTag("PlayerBullet") 
            || other.gameObject.CompareTag("Healthpack"))
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instantiate(snowBallEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        //Different bullet damage
        
    }



}

