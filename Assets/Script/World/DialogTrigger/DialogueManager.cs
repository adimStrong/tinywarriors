using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
   
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public float timeToNextScript = 3f;
    
   
    public GameObject dialogueUI;

    public GameObject jumpBtn;

    public bool isJumping;

    // Use this for initialization
    void Start()
    {
        if (isJumping)
        {
            jumpBtn.SetActive(false);
        }
        dialogueUI.SetActive(false);

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();
       
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();



    }

    public void DisplayNextSentence()
    {

     
        if (sentences.Count == 0)
        {

            Invoke("EndDialogue", 3f);
        }
        else
        {

           

            dialogueUI.SetActive(true);
            animator.SetTrigger("IsOpen");


            string sentence = sentences.Dequeue();
            StopAllCoroutines();

            StartCoroutine(TypeSentence(sentence));
            StartCoroutine(delayToNextSentence());
        }
      
    }

  


    IEnumerator delayToNextSentence()
    {
        yield return new WaitForSeconds(timeToNextScript);
        DisplayNextSentence();
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    void EndDialogue()
    {
        if (isJumping)
        {
            jumpBtn.SetActive(true);
        }
        dialogueUI.SetActive(false);
        animator.SetTrigger("IsClose");
    }
}
