using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    [SerializeField] private int healAmount = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("i hit player ady!!!!!!!!!!!");
            player.heal(healAmount + 1);
            Destroy(gameObject);

        }


    }
}
