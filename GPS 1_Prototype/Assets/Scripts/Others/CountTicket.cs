using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountTicket : MonoBehaviour
{
    Text text;
    public static int ticketAmount;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        text = GetComponent<Text>();
    }

    void Update()
    {   
        text.text = ticketAmount.ToString();
    }
}
