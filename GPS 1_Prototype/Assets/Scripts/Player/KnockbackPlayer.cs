using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : PlayerMovement
{
    public int damageGet;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //HeartsHealthSystem.HurtPlayer(damageGet);
        //collision.GetComponent<AudioSource>().Play();  //play sfx when collide

        var player = collision.GetComponent<PlayerMovement>();  //use the playerMovement script
        player.knockbackCount = player.knockbackLength;

        player.knockbackCount = 5;
        if (collision.transform.position.x < transform.position.x || collision.transform.position.y < transform.position.y)
        {
            player.isKnockbackRight = true;
        }
        else
        {
            player.isKnockbackRight = false;
        }


    }
}
