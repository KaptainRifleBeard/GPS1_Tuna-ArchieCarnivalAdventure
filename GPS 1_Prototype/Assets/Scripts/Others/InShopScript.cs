using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InShopScript : MonoBehaviour
{
    public Transform buttonPrefabs;
    public GameObject[] itemPrefabs;
    private Transform theWeapon;

    int randItem;

    int num = 1;

    void Start()
    {
         randItem = Random.Range(0, itemPrefabs.Length);
    }

    void Update()
    {
        if(num > 0)
        {
            GameObject item = Instantiate(itemPrefabs[randItem], buttonPrefabs.position, transform.rotation);
            num--;
        }


    }
}
