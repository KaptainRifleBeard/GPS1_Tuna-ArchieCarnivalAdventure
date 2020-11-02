using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayMode : MonoBehaviour
{
   public static bool isDual = false;

    public void SoloGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    public void DualGame()  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("isDual");
        isDual = true;

    }

    public void backFromSelectionMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    public bool getIsDual()
    {
        return isDual;
    }
}
