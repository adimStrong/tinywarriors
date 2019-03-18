using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRed : MonoBehaviour
{
    public float speed;

    public Transform[] moveSpots;

    private int randomSpot;

    private float waitTime;
    public float startWaitTime;
    public  bool canMove;

    private void Start()
    {

        canMove = false;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

            // if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            //  {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            //   }

        }

    }



    public void BossRedReady()
    {
        canMove = true;

    }

}
