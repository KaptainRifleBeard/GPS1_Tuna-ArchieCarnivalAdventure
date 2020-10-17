using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public Transform laserPos;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public float attackRadius;
    private float attackTime = 0f;
    public bool isShoot = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoot = startTimeBtwShoot;
    }

    public IEnumerator shootDuration()
    {
        yield return new WaitForSeconds(2f);
        attackTime = 0f;
        isShoot = true;

    }

    void Update()
    {
        
    }
}
