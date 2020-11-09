using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject ui;
    public GameObject ui2;

    private void Start()
    {
        if(SelectPlayMode.isDual == true)
        {
            ui.SetActive(true);
            ui2.SetActive(true);
        }
        else
        {
            ui.SetActive(true);
        }
    }

}
