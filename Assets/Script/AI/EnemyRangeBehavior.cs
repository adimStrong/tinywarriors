using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeBehavior : MonoBehaviour
{
    public float speed;
    public float stopingDistance;
    public float retreatDistance;

    public Transform player;

    private SpriteRenderer spriteRenderer;

    private float timeBtwShoots;
    public float startBtwShoots;
    private Animator anim;
    public GameObject projectile;
    public float timeToRespawnProjectile;
    public bool isStationary;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeBtwShoots = startBtwShoots;
    }

    private void Update()
    {
        spriteRenderer.flipX = (player.transform.position.x < transform.position.x);
        if (!isStationary)
        {
            if (Vector2.Distance(transform.position, player.position) > stopingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {

                transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(transform.position.x, player.position.y), speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        if(timeBtwShoots <= 0 && Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            anim.SetTrigger("Attack");

            StartCoroutine(delayToShoot());
            timeBtwShoots = startBtwShoots;

        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }

    IEnumerator delayToShoot()
    {
        yield return new WaitForSeconds(timeToRespawnProjectile);
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

}