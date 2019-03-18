using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float timeBtwSpawn;
    public float startBtwSpawn;

    public GameObject echo;
    public Player player;
    float input;

    private void Start()
    {
        player = GetComponent<Player>();
       
;    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (player.GetComponent<Player>().isDashing)
        {
            if (timeBtwSpawn <= 0)
            {
                // spawn echo

                //  int rand = Random.Range(0, echo.Lenght); use this for spawing multiple trails

                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                timeBtwSpawn = startBtwSpawn;
                Destroy(instance, 3f);
          }
          else
           {
               timeBtwSpawn -= Time.deltaTime;
            }
        }
    }


}
