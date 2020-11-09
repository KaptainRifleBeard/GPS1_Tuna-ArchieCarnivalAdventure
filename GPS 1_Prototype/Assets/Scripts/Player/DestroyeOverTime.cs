using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For bullet effect

public class DestroyeOverTime : MonoBehaviour
{
    public float lifeTime;
   
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}

