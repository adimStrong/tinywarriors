using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public Animator anim;
    public GameObject deathEffect;

    public Slider bossHpSlider;
    public bool isBoss;
    public bool isBat;


    private void Start()
    {
        if (isBoss)
        {
            bossHpSlider.value = health;
        }
        anim = GetComponent<Animator>();
    }


   
    public void TakeDamage(float damage)
    {

        health -= damage;
        if (isBoss)
        {
           
            bossHpSlider.value = health;
        }
        if (health<= 0)
        {
            if (isBat)
            {
                FindObjectOfType<AudioController>().Play("BatDead");
            }
            Die();
        }
       

    }

    void Die()
    {
      
        anim.SetTrigger("isDead");

        StartCoroutine(waitToDestroy());

    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        if (isBoss)
        {
            FindObjectOfType<BossRed>().canMove = false;
            yield return new WaitForSeconds(2.5f);
        }
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
