//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class PlayerHealth : MonoBehaviour
//{
//    public int health;

//    //public bool isRestartGame = false;
//    [SerializeField]
//    GameObject RestartMenuUI;

//    void Start()
//    {
//        health = 6;
//        RestartMenuUI.SetActive(false);
//    }

//    //private void OnTriggerEnter2D(Collider2D collider)
//    //{
//    //    if(collider.gameObject.CompareTag("EnemyBullet") || collider.gameObject.CompareTag("Enemy"))
//    //    {
//    //        health -= 2;
//    //    }
//    //}

//    void Update()
//    {
//        if (health <= 0)
//        {
//            Debug.Log("die");
//            Destroy(this.gameObject);
//            //Application.LoadLevel(Application.loadedLevel);
//            RestartMenuUI.SetActive(true);
//            //restartGame();

//        }
//    }


//    void restartGame()
//    {
//        //Application.LoadLevel(Application.loadedLevel);
//    }

//}
