using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public int sceneIndex;


    public void OnActivation()
    {

        SceneManager.LoadSceneAsync(sceneIndex);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnActivation();
        }
    }
}
