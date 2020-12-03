using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraTarget : MonoBehaviour
{
    public Camera cam;

    public void changeCam()
    {
        if (SelectPlayMode.isDual == true)
        {
            if (healthVisual.p1IsDead == true && healthVisualB.p2IsDead == false)
            {
                cam.transform.position = new Vector3(PlayerBSpawn.playerBRespawn.transform.position.x, PlayerBSpawn.playerBRespawn.transform.position.y, -100);
            }
            else if (healthVisual.p1IsDead == false && healthVisualB.p2IsDead == true)
            {
                cam.transform.position = new Vector3(PlayerSpawn.playerRespawn.transform.position.x, PlayerSpawn.playerRespawn.transform.position.y, -100);
            }

        }
    }
}
