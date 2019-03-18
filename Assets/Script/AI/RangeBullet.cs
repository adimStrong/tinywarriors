using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBullet : MonoBehaviour
{
    public Transform player;
    private Vector2 target;
    public GameObject effectAfterDestroy;
    public float speed;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Invoke("DestroyProjectile", 2f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {

            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Instantiate(effectAfterDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
