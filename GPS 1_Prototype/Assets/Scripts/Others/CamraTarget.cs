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
            if (HeartSystem.p1IsDead == true && HeartSystemB.p2IsDead == false)
            {
                cam.transform.position = new Vector3(PlayerBSpawn.playerBRespawn.transform.position.x, PlayerBSpawn.playerBRespawn.transform.position.y, -100);
            }
            else if (HeartSystem.p1IsDead == false && HeartSystemB.p2IsDead == true)
            {
                cam.transform.position = new Vector3(PlayerSpawn.playerRespawn.transform.position.x, PlayerSpawn.playerRespawn.transform.position.y, -100);
            }

        }
    }
}
