using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float bulletSpeed;
    public Rigidbody2D rb;
    public GameObject snowBallEffect;
    public float speed;
    //GameObject prefab;

    //public float fireRate = 1;
    //private float nextFire = 0.0F;
   

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        //prefab = Resources.Load("Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        // rb.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);
        //if (Input.GetKeyDown("t")) && Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    GameObject projectile = Instantiate(prefab) as GameObject;
        //    projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
        //    Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //    rb.velocity = Camera.main.transform.forward * 40;
        //}

        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RegionDetectPlayer") || other.gameObject.CompareTag("Stage") || other.gameObject.CompareTag("RoomManager") 
            || other.gameObject.CompareTag("RoomBoundary") || other.gameObject.CompareTag("Ticket"))
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instantiate(snowBallEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        
    }



}
//public float m_BulletSpeed = 0.05f;
//public float m_Destroydelay = 3f;
//// Start is called before the first frame update
//void Start()
//{
//    Destroy(gameObject, m_Destroydelay);
//}

//// Update is called once per frame
//void Update()
//{
//    transform.position += Vector3.up * m_BulletSpeed;
//}

//---------------------------------------------------------------------------------------------------
//if (Input.GetKeyDown("w"))
//{
//    transform.position += Vector3.up * m_BulletSpeed;
//}
//else if (Input.GetKeyDown("s"))
//{
//    transform.position += Vector3.down * m_BulletSpeed;
//}
//else if (Input.GetKeyDown("a"))
//{
//    transform.position += Vector3.left * m_BulletSpeed;
//}
//else if (Input.GetKeyDown("d"))
//{
//    transform.position += Vector3.right * m_BulletSpeed;
//}


