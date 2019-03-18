using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetBehavior : MonoBehaviour
{
    public float distance = 2;

    private Player player;

   

    private void Start()
    {
        player = Player.instance;
    }

    private void Update()
    {

       
            Vector3 localPos = new Vector3(
            player.isFacingRight() ? -1f : 1f,
            General.Direction2Vector(player.GetDirection()).y,
            0f
               );


            transform.localPosition = localPos * distance;
        }


}
