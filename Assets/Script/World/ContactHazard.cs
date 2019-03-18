using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour {

	public float damageOnHit;

  

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponentInParent<Player>();

            Debug.Log("Tinamaan ang player");
            if (player != null)
            {
                   player.ApplyDamage(damageOnHit);
            }

        }
    }
   


}
