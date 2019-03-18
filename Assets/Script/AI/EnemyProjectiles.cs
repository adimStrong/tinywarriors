using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{

    // this is for spawning projectiles enemy
    public GameObject projectile;
    public Transform firePos;

    private float timeBtwShots;
    public bool isFiring;
    public float startTimeBtwShots;

    private void Start()
    {

        isFiring = false;
        firePos = gameObject.transform;
    }

    private void Update()
    {

            if (timeBtwShots <= 0)
            {
                isFiring = true;
                Shoot();
                timeBtwShots = startTimeBtwShots;

            }
            else
            {

                timeBtwShots -= Time.deltaTime;
            }


        

        void Shoot()
        {
            if (FindObjectOfType<BossRedTrigger>().hasTrigger)
            {
                isFiring = false;
                Instantiate(projectile, firePos.position, firePos.rotation);

                FindObjectOfType<AudioController>().Play("BossRedAttack");
            }

        }

    }
}