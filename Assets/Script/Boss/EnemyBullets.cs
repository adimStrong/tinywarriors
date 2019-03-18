using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullets : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
   
    public float lifeTime;


    private void Start()
    {

        Invoke("DestroyBullet", lifeTime);
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }


    void DestroyBullet()
    {

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Enemy")
        {
        /*    EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(40f);

            // to insert player receive damage
            }*/

            Instantiate(impactEffect, transform.position, transform.rotation);

            StartCoroutine(delayToDestroy());
        }
    }

    IEnumerator delayToDestroy()
    {

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);


    }
}
