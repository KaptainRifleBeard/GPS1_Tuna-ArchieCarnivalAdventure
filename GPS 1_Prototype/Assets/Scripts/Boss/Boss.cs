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
    public SpriteRenderer SetSpriteColor;

    public IEnumerator BossDie()
    {
        yield return new WaitForSeconds(3f);
    }
    IEnumerator getDamageVFX()
    {
        for (int n = 0; n < 2; n++)
        {
            SetSpriteColor.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            SetSpriteColor.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
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
            SceneManager.LoadScene("ThanksForPlaying");

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            StartCoroutine(getDamageVFX());
            takeDamage(5);
        }
        if (other.gameObject.CompareTag("CheeseBullet"))
        {
            StartCoroutine(getDamageVFX());
            takeDamage(10);
        }
        if (other.gameObject.CompareTag("BubbleBullet"))
        {
            StartCoroutine(getDamageVFX());
            takeDamage(3);
        }

    }

    void Update()
    {
        boss.transform.localScale = new Vector3(1f, 1f, 1f);

    }
}
