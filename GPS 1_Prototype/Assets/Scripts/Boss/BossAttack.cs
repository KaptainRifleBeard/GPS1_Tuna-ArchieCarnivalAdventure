	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserPrefab;

    public static GameObject target = null;

    //public Transform target;      
    public Transform shootPos_left;
    public Transform shootPos_right;
    public Transform laserPos;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public float attackRadius;
    private float attackTime = 0f;
    public bool isShoot = false;
    public bool isLaser = false;
    public bool bossMove = true;

    bool spawn = false;
    int count = 0;

    RaycastHit2D hit;
    public LineRenderer lineOfSight;

    //! 3 seconds aiming 
    public IEnumerator aimDuration()
    {
        yield return new WaitForSeconds(3f);
        lineOfSight.enabled = false;
        isLaser = true;
    }
    //! 6 seconds laser attack
    public IEnumerator laserDuration()
    {
        yield return new WaitForSeconds(6f);
        attackTime = 0f;  //reset attack time
        count = 0;  //reset number prefab of laser
        isLaser = false;
        bossMove = true;
    }

    //! After laser, wait 3 seconds to shoot
    //! Boss shoot bullet for 10 seconds


    void shoot()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < attackRadius)
        {
            if (timeBtwShoot <= 0)
            {
                Instantiate(bullet, shootPos_left.position, transform.rotation);
                Instantiate(bullet, shootPos_right.position, transform.rotation);

                timeBtwShoot = startTimeBtwShoot;  //shoot delay
            }
            else
            {
                timeBtwShoot -= Time.deltaTime;
            }

        }
    }

    void laser()
    {
        float distance = 10f;

        if (isLaser)
        {
            bossMove = false;
            if (count < 1 && spawn == false)
            {
                if (count < 1)
                {
                    spawn = true;
                    Instantiate(laserPrefab, laserPos.position, Quaternion.identity);
                    count++;

                }
                if (count == 1)
                {
                    StartCoroutine(laserDuration());
                    spawn = false;
                }
            }

            //laserPrefab.SetActive(true);

            if (lineOfSight.enabled == true)
            {
                //Display aim line
                Vector2 endPos = laserPos.position + Vector3.down * distance;
                RaycastHit2D hit = Physics2D.Linecast(laserPos.position, endPos, 1 << LayerMask.NameToLayer("Default"));
                Debug.DrawLine(laserPos.position, endPos, Color.red);

            }
        }
    }

    void Start()
    {
        timeBtwShoot = startTimeBtwShoot;
        lineOfSight.enabled = false;

        //laserPrefab.SetActive(false);
        isLaser = false;
        bossMove = true;

        float distanceToClosestPlayer = Mathf.Infinity;
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                target = currentPlayer; 
                Debug.Log(target + "target is this");

            }
        }
    }

    void Update()
    {

        Debug.Log(attackTime);
        attackTime += Time.deltaTime;
        if (target != null)
        {
            //Hard code (need to count by yourself)
            if (attackTime <= 30)
            {
                if (attackTime >= 0 && attackTime <= 10)
                {
                    isShoot = true;
                    if (isShoot)
                    {
                        shoot();
                    }
                }
                if (attackTime >= 11 && attackTime <= 13)
                {
                    isShoot = false;
                }
                if (attackTime >= 14 && attackTime <= 24)
                {
                    isShoot = true;
                    if (isShoot)
                    {
                        shoot();
                    }
                }
                if (attackTime >= 25 && attackTime <= 28)
                {
                    isShoot = false;
                }
                if (attackTime >= 29 && attackTime < 30)
                {
                    isShoot = true;
                    if (isShoot)
                    {
                        shoot();
                    }
                }
            }
            else if (attackTime >= 30)
            {

                isShoot = false;
                bossMove = false;

                if (attackTime <= 33)
                {
                    lineOfSight.enabled = true;
                    StartCoroutine(aimDuration());
                }
                else
                {
                    isLaser = true;
                    if (isLaser)
                    {
                        laser();
                    }
                }

                
            }

        }
    }

}

/*
if (attackTime <= 5)
{
    StartCoroutine(shootDuration());
    lineOfSight.enabled = false;
    isShoot = true;
    shoot();
}
if (attackTime >= 5) //is laser attack now
{
    isShoot = false;

    //Laser attack
    if (attackTime <= 5.5)
    {
        lineOfSight.enabled = true;
    }
    else if (attackTime >= 5.5)
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
*/