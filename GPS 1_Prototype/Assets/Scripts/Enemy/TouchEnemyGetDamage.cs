
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemyGetDamage : MonoBehaviour
{
    public static HeartSystem Health;

    public int damageAmount = 0;
    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>();

        if (player != null) {
            // We hit the Player
            Vector3 knockbackDir = (player.GetPosition() - transform.position).normalized;
            player.DamageKnockback(knockbackDir, 0.5f, damageAmount);
        }

        PlayerB playerB = collider.GetComponent<PlayerB>();

        if (playerB != null)
        {
            // We hit the Player
            Vector3 knockbackDir = (playerB.GetPosition() - transform.position).normalized;
            playerB.DamageKnockback(knockbackDir, 0.5f, damageAmount);
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.CompareTag("Player"))
        {
            Health.takeDamage(damageAmount);
        }
        */

    }
}
