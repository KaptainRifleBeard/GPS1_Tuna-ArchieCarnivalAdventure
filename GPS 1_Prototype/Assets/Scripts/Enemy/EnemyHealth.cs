using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] playerBullet;
    public GameObject[] dropItems;

    private int randNum;
    public int health;
    bool walk = false;

    private enum State {idle, walking, hurt}
    private State state = State.idle;

    public Animator animator;



    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
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
        int itemNum;
        int randNum;


        randNum = Random.Range(0, 101); // 100% total for determining loot chance;
        Debug.Log("Random Number is " + randNum);

        if (randNum > 40 && randNum <= 75) 
        {
            itemNum = 0; //num in item list
            Instantiate(dropItems[itemNum], gameObject.transform.position, Quaternion.identity);

        }
        else if (randNum > 22 && randNum <= 39)
        {
            itemNum = 1; //num in item list
            Instantiate(dropItems[itemNum], gameObject.transform.position, Quaternion.identity);

        }
    }

}
