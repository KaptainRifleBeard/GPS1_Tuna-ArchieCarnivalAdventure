using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadToNextLevel();
        }
    }
    public void LoadToNextLevel()
    {
        Debug.Log("NextLevel");
        SceneManager.LoadScene("WinScreen");
        //SceneManager.UnloadScene("Level 1");

    }
}
