using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject barrier;
    public Joystick joystick;


    private void Start()
    {
       
    }
    private void Update()
    {
       
            for (int i = 0; i < popUps.Length; i++)
            {
                if(i == popUpIndex)
                {
                FindObjectOfType<Player>().canMove = true;
                popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }

            }
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || joystick.Horizontal != 0)
            {
                popUpIndex++;
            }
        } else if (popUpIndex == 1)
        {
            if (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                popUpIndex++;
            }

        }
        else if( popUpIndex == 2)
        {
            if (Input.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 3)
        {
            if (FindObjectOfType<Player>().isDashing)
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 4)
        {
           StartCoroutine(waitToDisable());
            barrier.SetActive(false);
               
        }

        IEnumerator waitToDisable()
        {

            yield return new WaitForSeconds(4f);
            popUpIndex++;
        }
    }
}
