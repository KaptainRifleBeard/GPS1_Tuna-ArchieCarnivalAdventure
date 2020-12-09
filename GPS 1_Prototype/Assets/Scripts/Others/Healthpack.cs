using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
    public int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        PlayerB playerB = collision.GetComponent<PlayerB>();

        if (player != null)
        {
            Debug.Log("Add HEALTH");
            collision.GetComponent<HeartSystem>().healHealth(healAmount);
            Destroy(gameObject);

        }
        if (playerB != null)
        {
            collision.GetComponent<HeartSystemB>().healHealth(healAmount);
            Destroy(gameObject);

        }

    }
}
