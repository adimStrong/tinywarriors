using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRedTrigger : MonoBehaviour
{
    public GameObject bossRedBlocker;

    public bool hasTrigger;

    public Slider slide;

     void Start()
    {
        slide.gameObject.SetActive(false);
        hasTrigger = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTrigger) { 
        hasTrigger = true;
            if (other.CompareTag("Player"))
            {

                FindObjectOfType<BossRed>().BossRedReady();
                slide.gameObject.SetActive(true);
                bossRedBlocker.SetActive(true);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            }
        }
    }
}
