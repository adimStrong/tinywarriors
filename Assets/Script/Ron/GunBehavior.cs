using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunBehavior : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform firePos;

    private bool facingRight;

    private float timeBtwShots;

    public float startTimeBtwShots;

    public Joystick joystick;

    private void Start()
    {
        facingRight = true;
    }


    private void Update()
    {
        Flip(Input.GetAxis("Horizontal"));
        if (timeBtwShots <= 0)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {

            timeBtwShots -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        if (FindObjectOfType<Player>().canMove)
        {
            FindObjectOfType<AudioController>().Play("pistola");
            Instantiate(projectile, firePos.position, firePos.rotation);
        }

    }
    private void Flip(float horizontal)
    {
        if (joystick.Horizontal > 0 && !facingRight || joystick.Horizontal < 0 && facingRight || Input.GetAxis("Horizontal") > 0 && !facingRight || Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }



    }


}
