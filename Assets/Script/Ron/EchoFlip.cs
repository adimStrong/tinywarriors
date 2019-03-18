using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoFlip : MonoBehaviour
{



    private bool facingRight;

    private void Start()
    {
        Flip(Input.GetAxis("Horizontal"));

       
    }


    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }



    }


   
}
