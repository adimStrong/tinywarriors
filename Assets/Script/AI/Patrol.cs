using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;


    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down,distance);
        if (groundInfo.collider == false)
        {
            // collider does not hit anything
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                movingRight = true;

            }

        }

    }
}
