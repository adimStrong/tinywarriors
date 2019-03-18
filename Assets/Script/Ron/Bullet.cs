using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (hitInfo.tag != "Player")
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(40f);


            }
            FindObjectOfType<CameraShake>().CameraShaker();
            Instantiate(impactEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioController>().Play("Collide");
           
            Destroy(gameObject);
        }
    }
}
