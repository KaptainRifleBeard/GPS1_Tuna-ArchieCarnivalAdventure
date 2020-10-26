using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountKill : MonoBehaviour
{
    Text text;
    public static int killAmount;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = killAmount.ToString();
    }
}
