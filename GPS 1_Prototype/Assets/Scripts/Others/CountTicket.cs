using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountTicket : MonoBehaviour
{
    public Text Score;
    public static int ticketAmount = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Score = GetComponent<Text>();
    }

    void Update()
    {
        Score.text = ticketAmount.ToString();
    }
}
