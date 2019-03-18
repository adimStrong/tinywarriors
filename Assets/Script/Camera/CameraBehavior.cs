using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target;
    public float dumpingTime = 1f;

    public float PPU = 16f;

    private Vector3 velocity;


    private Vector3 proxyPos;

    private void LateUpdate()
    {
        proxyPos = Vector3.SmoothDamp(proxyPos, target.position, ref velocity, dumpingTime);

            transform.position = new Vector3(
            Mathf.Round(proxyPos.x * PPU) / PPU,
              Mathf.Round(proxyPos.y * PPU) / PPU,
              -10f
        );


        transform.position += Vector3.forward * -10f;
    }
}
