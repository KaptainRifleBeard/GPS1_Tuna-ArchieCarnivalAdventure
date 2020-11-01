using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform camPos;
    public GameObject cam;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            cam.transform.position = new Vector3(camPos.position.x, camPos.position.y, -10);
        }

    }

}
