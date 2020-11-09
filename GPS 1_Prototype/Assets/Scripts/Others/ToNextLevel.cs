using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextLevel : MonoBehaviour
{
    public GameObject winScreen;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
        }

    }
}
