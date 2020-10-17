using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserAttack : MonoBehaviour
{
    BossAttack isActive;
    public GameObject laser;

    private void Awake()
    {
        laser.SetActive(false);
    }
    void Update()
    {
        if (isActive.isLaser == true)
        {
            laser.SetActive(true);
        }
    }
}
