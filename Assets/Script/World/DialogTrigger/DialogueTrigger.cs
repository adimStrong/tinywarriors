using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isJumping;
    public GameObject ronStartPoint;
    public bool isDeady;
    public GameObject player;
    public GameObject blackScreen;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (isJumping)
            {
                FindObjectOfType<DialogueManager>().isJumping = true;
            }
           
            if (isDeady)
            {
                player.transform.position = ronStartPoint.transform.position;
                blackScreen.SetActive(true);
                blackScreen.GetComponent<Animator>().SetTrigger("blackScreenOver");
            }
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            if (!isDeady)
            {
                Destroy(this.gameObject);
            }
                }

    }
   
}
