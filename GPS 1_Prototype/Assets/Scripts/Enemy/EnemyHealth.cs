using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] playerBullet;
    public GameObject[] dropItems;

    private int randNum;
    public int health;

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health = health - 5;    //later change it to player bullet damage

            if (health < 0)
            {
                Destroy(gameObject);
                itemDrop();
            }
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
    }

}
