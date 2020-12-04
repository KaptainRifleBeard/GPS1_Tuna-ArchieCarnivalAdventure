using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] playerBullet;
    public GameObject[] dropItems;

    public int health;

    public Animator animator;
    public SpriteRenderer SetSpriteColor;

    IEnumerator getDamageVFX()
    {
        for (int n = 0; n < 2; n++)
        {
            SetSpriteColor.color = Color.red;
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
            health = health - 5;    //later change it to player bullet damage

            if (health < 0)
            {
                FindObjectOfType<AudioManager>().Play("EnemyDeath");

                CountKill.killAmount += 1;
                Destroy(gameObject);
                itemDrop();
            }
        }


    }
    void itemDrop()
    {
        int randNum = Random.Range(0, 100); // 100% total for determining loot chance;;

        if (randNum > 0 && randNum <= 13) 
        {
            Instantiate(dropItems[0], gameObject.transform.position, Quaternion.identity);
        }
        if (randNum > 14 && randNum <= 23)
        {
            Instantiate(dropItems[1], gameObject.transform.position, Quaternion.identity);

        }
        if (randNum > 24 && randNum <= 40)
        {
            Instantiate(dropItems[2], gameObject.transform.position, Quaternion.identity);

        }
    }

}
