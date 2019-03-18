using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject contBtn;
    public Animator textDisplayAnim;
    public Animator animForBlackScreen;
    public GameObject blackScreenPanel;
    public bool hasBlackScreen;
    public GameObject mobileUI;

    private void Start()
    {
        if (hasBlackScreen)
        {

            blackScreenPanel.SetActive(true);
            mobileUI.SetActive(false);
            StartCoroutine(Type());
        }
       

    }

    IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
     
         

    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            contBtn.SetActive(true);
        }
    }

    public void NextSentence()
    {
        Debug.Log("working");
        FindObjectOfType<AudioController>().Play("click");
        textDisplayAnim.SetTrigger("change");
       
            contBtn.SetActive(false);
            
        if (index < sentences.Length - 1)
        {
           
                animForBlackScreen.SetTrigger("isOpen");
               


            index++;
            textDisplay.text = "";

            StartCoroutine(Type());

        }
        else
        {
            if (hasBlackScreen)
            {
                animForBlackScreen.SetTrigger("blackScreenOver");
                Destroy(blackScreenPanel, 2f);
            }
            FindObjectOfType<Player>().ToStartPoint();
            FindObjectOfType<Player>().canMove = true;

                contBtn.SetActive(false);

            blackScreenPanel.SetActive(false);
            mobileUI.SetActive(true);
            textDisplay.text = "";

        }
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("it work");
        if (other.CompareTag("Player"))
        {
            blackScreenPanel.SetActive(true);
            mobileUI.SetActive(false);
            StartCoroutine(Type());
        }
    }

   
}
