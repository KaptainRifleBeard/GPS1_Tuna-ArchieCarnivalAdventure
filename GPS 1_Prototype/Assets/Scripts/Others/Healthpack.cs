using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    [SerializeField] private int healAmount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        PlayerB playerB = collision.GetComponent<PlayerB>();

        if (player != null)
        {
            player.heal(healAmount + 1);
            Destroy(gameObject);

        }
        if (playerB != null)
        {
            playerB.heal(healAmount + 1);
            Destroy(gameObject);

        }

    }
}
