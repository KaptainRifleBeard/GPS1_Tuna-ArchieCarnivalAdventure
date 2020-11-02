using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Vector3 direction;
    public Transform target;
    public Transform barrier;
    protected Rigidbody2D rb;
    protected float angle;

    public GameObject[] player1;
    public GameObject[] player2;

    [HideInInspector] public Transform[] p1Position;
    [HideInInspector] public Transform[] p2Position;
    [HideInInspector] public int randPlayer1;
    [HideInInspector] public int randPlayer2;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player1 = GameObject.FindGameObjectsWithTag("Player");
        player2 = GameObject.FindGameObjectsWithTag("Player2");

        randPlayer1 = Random.Range(0, player1.Length);
        randPlayer2 = Random.Range(0, player2.Length);
    }

    void Update()  
    {
        //! Player1
        //To rotate the enemy facing the player
        rb.AddForce(p1Position[randPlayer1].position - transform.position, ForceMode2D.Impulse);

        //! Player2
        rb.AddForce(p2Position[randPlayer2].position - transform.position, ForceMode2D.Impulse);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
    }

}
