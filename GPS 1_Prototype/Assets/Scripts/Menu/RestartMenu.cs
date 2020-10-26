using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class RestartMenu : PlayerSpawn
{
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void restartFromBoss()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    
    }
}
