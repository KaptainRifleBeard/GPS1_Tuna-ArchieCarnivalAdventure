using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] playerBullet;
    public GameObject dropItems;

    private int randNum;
    public int health;
    bool walk = false;

    public Animator animator;
    public SpriteRenderer SetSpriteColor;

    IEnumerator getDamageVFX()
    {
        for (int n = 0; n < 2; n++)
        {
            SetSpriteColor.color = Color.clear;
            yield return new WaitForSeconds(0.1f);
            SetSpriteColor.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            StartCoroutine(getDamageVFX());

            walk = true;
            health = health - 5;    //later change it to player bullet damage

            if (health < 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyDeath");

                CountKill.killAmount += 1;
                Destroy(gameObject);
                itemDrop();
            }
        }
        else
        {
            walk = false; 

        }


    }
    public void Update()
    {
        if(walk)
        {
            //animator.SetBool("isGetDamage", true);
        }
        else
        {
           // animator.SetBool("isGetDamage", false);
        }
    }

    void itemDrop()
    {
        randNum = Random.Range(0, 100);
        if (randNum > 0 && randNum <= 49)
        {
            Instantiate(dropItems, gameObject.transform.position, Quaternion.identity);

        }

        /*
        int itemNum;
        int randNum;


        randNum = Random.Range(0, 101); // 100% total for determining loot chance;
        Debug.Log("Random Number is " + randNum);

        
        if (randNum > 40 && randNum <= 75) 
        {
            itemNum = 1; //num in item list
            Instantiate(dropItems[itemNum], gameObject.transform.position, Quaternion.identity);

        }
        if (randNum > 0 && randNum <= 49)
        {
            itemNum = 0; //num in item list

        }
        */
    }

}
