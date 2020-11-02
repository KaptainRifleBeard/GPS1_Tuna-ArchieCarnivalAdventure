using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    public GameObject[] weapon;
    public Transform pos;
    public KeyCode switchWeapon;
   
    
    void Start()
    {
        Pick();
    }

    void Pick()
    {
        int randomIndex = Random.Range(0, weapon.Length);
        GameObject clone = Instantiate(weapon[randomIndex], pos.position, Quaternion.identity);

        
    }
    
    void Update()
    {
       
    }
}
