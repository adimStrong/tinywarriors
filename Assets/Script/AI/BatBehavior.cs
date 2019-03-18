using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Player player;


    float topY;
    float buttomY;
    float x;


    private void Start()
    {

        //get player instance from player class
        player = Player.instance;

        spriteRenderer = GetComponent<SpriteRenderer>();

        // current x pos
        x = transform.position.x;
        topY = transform.position.y + 1.5f;
        buttomY = transform.position.y - 1.5f;
    }

    private void Update()
    {
        Movement();
        LookAtPlayer();
    }


    void Movement()
    {

        float t = Mathf.Sin(1.5f * Time.time) / 2.0f * 1.5f;


        transform.position = new Vector3(x, Mathf.Lerp(buttomY, topY, t), 0);
    }

    void LookAtPlayer()
    {
        // face player since we use a sprite that is already facing left
        spriteRenderer.flipX = (player.transform.position.x > x);


    }
}
