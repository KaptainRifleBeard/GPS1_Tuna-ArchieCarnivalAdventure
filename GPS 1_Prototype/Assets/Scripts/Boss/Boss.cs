using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject boss;
    public HealthBar healthBar;

    public int maxHealth = 300;
    public int curHealth;

    public IEnumerator BossDie()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ThanksForPlaying");
    }

    void Start()
    {
        curHealth = maxHealth;
        healthBar.setHealth(curHealth, maxHealth);
    }

    public void takeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.setHealth(curHealth, maxHealth);

        if (curHealth <= 0)
        {
            Debug.Log("Boss dead");

            FindObjectOfType<AudioManager>().Play("BossDeath");
            Destroy(gameObject);
            StartCoroutine(BossDie());
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            takeDamage(5);
        }

    }

    void Update()
    {
        boss.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
