using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float timeToDestroy;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
      
          

        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);


    }
}
