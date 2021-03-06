﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public GameObject virtualCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2")  && !other.isTrigger)
        {
            virtualCamera.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        virtualCamera.SetActive(false);
    }

}