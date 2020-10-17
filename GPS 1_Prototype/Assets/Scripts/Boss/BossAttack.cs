using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserPrefab;

    public Transform target;
    public Transform[] shootPos;
    public Transform laserPos;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public float attackRadius;
    private float attackTime = 0f;
    public bool isShoot = false;
    public bool isLaser = false;
    RaycastHit2D hit;
    public LineRenderer lineOfSight;

    //**************************************************************************************************//
    // Functions
    //**************************************************************************************************//
    public IEnumerator shootCooldown()
    {
        yield return new WaitForSeconds(2.5f);
        attackTime = 0f;
        isShoot = true;
    }
    public IEnumerator laserDuration()
    {
        yield return new WaitForSeconds(2f);
        isLaser = false;
    }

    public IEnumerator aimDuration()
    {
        yield return new WaitForSeconds(0.5f);

        isLaser = true;

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

    void laser()
    {
        float distance = 10f;
        float castDist = distance;

        if(lineOfSight.enabled == true)
        {
            //Display aim line
            Vector2 endPos = laserPos.position + Vector3.down * distance;
            RaycastHit2D hit = Physics2D.Linecast(laserPos.position, endPos, 1 << LayerMask.NameToLayer("Default"));
            Debug.DrawLine(laserPos.position, endPos, Color.red);

            
        }

        if (isLaser)
        {
            laserPrefab.SetActive(true);
            //isLaser = false;
            //startTimeBtwShoot = 2;

            //if (timeBtwShoot <= 0)
            //{
            //    //Instantiate(laserPrefab, laserPos.transform.position, Quaternion.identity);
            //    timeBtwShoot = startTimeBtwShoot;  //shoot delay
            //}
            //else
            //{
            //    timeBtwShoot -= Time.deltaTime;
            //}
        }
    }


    //**************************************************************************************************//
    // Update
    //**************************************************************************************************//
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoot = startTimeBtwShoot;
        lineOfSight.enabled = false;

        laserPrefab.SetActive(false);
        isLaser = false;
    }

    void Update()
    {
        Debug.Log(attackTime);
        attackTime += Time.deltaTime;
        if(target != null)
        {
            if (attackTime <= 5)
            {
                lineOfSight.enabled = false;
                isShoot = true;
                if (Vector3.Distance(target.position, transform.position) < attackRadius)
                {
                    shoot();
                }
            }
            if (attackTime >= 5) //is laser attack now
            {
                isShoot = false;

                //Laser attack
                if(attackTime <= 5.5)
                {
                    lineOfSight.enabled = true;
                }
                else if(attackTime >= 5.5)
                {
                    lineOfSight.enabled = false;
                    isLaser = true;
                    laser();
                }

                //Stop laser attack
                if (attackTime >= 7.5)
                {
                    isLaser = false;
                    laserPrefab.SetActive(false);
                }

                //Shooting attack
                if (isShoot == false)
                {
                    StartCoroutine(shootCooldown());

                }
            }
        }
        

    }
}
