using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static PlayerDeath instance;

    
    private void Awake()
    {
        instance = this;
    }
    //public static HeartsHealthSystem heartsHealthSystemStatic;
    //public GameObject a
    //// Start is called before the first frame update
    //bool m_isDestroy = false;

    ////Force/remind coder to use this function for destroying
    //public void Destroy()
    //{
    //    if (!m_isDestroy)
    //    {
    //        a.Destroy(gameObject);
    //        m_isDestroy = true;
    //    }
    //}

    ////Use this function to check
    //public bool IsDestroy
    //{
    //    get { return m_isDestroy; }
    //}

    //// Update is called once per frame
    
    Transform player;
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }
}
