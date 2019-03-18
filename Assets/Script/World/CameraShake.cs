using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Animator anim;
   




   public void CameraShaker()
    {

        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                anim.SetTrigger("camShaker");
                break;
            case 1:
                anim.SetTrigger("camShaker2");
                break;
            case 2:
                anim.SetTrigger("camShaker2");
                break;
        }
    }
}
