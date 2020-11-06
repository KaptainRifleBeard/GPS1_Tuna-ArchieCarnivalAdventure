using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    public static bool addHealth = false;
    [SerializeField] private int healAmount = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("i hit player ady!!!!!!!!!!!");
            player.heal(healAmount);
            addHealth = true;
            Destroy(gameObject);

        }


        PlayerB playerB = collision.GetComponent<PlayerB>();
        if (playerB != null)
        {
            Debug.Log("i hit player ady!!!!!!!!!!!");
            playerB.heal(healAmount);
            addHealth = true;
            Destroy(gameObject);

        }
    }
}
