using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public Transform[] shootPos;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public float attackRadius;
    private float attackTime = 0f;
    public bool isAttack = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoot = startTimeBtwShoot;
    }

    public IEnumerator checkCooldown()
    {
        yield return new WaitForSeconds(2.5f);
        attackTime = 0f;
        isAttack = true;
    }

    void shoot()
    {
        int randPos = Random.Range(0, shootPos.Length);

        if (timeBtwShoot <= 0)
        {
            Instantiate(bullet, shootPos[randPos].position, transform.rotation);
            timeBtwShoot = startTimeBtwShoot;  //shoot delay

        }
        else
        {
            timeBtwShoot -= Time.deltaTime;

        }
    }


    void Update()
    {
        //Debug.Log(attackTime);
        attackTime += Time.deltaTime;
        if(target != null)
        {
            if (attackTime <= 5)
            {
                isAttack = true;
                if (Vector3.Distance(target.position, transform.position) < attackRadius)
                {
                    shoot();
                }
            }
            if (attackTime >= 5)
            {
                isAttack = false;

                if (isAttack == false)
                {
                    StartCoroutine(checkCooldown());
                }
            }
        }
        

    }
}
