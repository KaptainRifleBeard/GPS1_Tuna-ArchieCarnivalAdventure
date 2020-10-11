using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BossRoom : MonoBehaviour
{
    public Transform camPos;
    public GameObject cam;
    public bool isBoss = false;

    public BoxCollider2D box;
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            cam.transform.position = new Vector3(camPos.position.x, camPos.position.y, -10);
            isBoss = true;
            if (isBoss)
            {
                var zoom = 8;
                Camera.main.orthographicSize = zoom;
                box.isTrigger = false;

            }
        }

    }

}
