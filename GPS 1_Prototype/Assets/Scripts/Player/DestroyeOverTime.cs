using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyeOverTime : MonoBehaviour
{
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
//public KeyCode myShoot = KeyCode.F;

//public GameObject bulletPrefab;
//public Transform bulletSpawnPOS;

//public float m_Shootdelay = 1f;
//float m_CurrentTime;

//void ShootingSemiAuto(KeyCode l_shoot)
//{
//    if (Input.GetKeyDown(l_shoot))
//    {
//        Debug.Log("shoot");
//        Instantiate(bulletPrefab, bulletSpawnPOS.position, Quaternion.identity);
//    }
//}

//void Start()
//{
//    m_CurrentTime = m_Shootdelay;
//}

//// Update is called once per frame
//void Update()
//{

//    ShootingSemiAuto(myShoot);
//}

