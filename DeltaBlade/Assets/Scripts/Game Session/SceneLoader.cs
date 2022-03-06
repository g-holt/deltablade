using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    int currentSceneIndex;


    // public void PlayAgain()
    // {Debug.Log("here 1");
    //     StartCoroutine("LoadCurrentLevel");
    // }


    public void NextLevel()
    {
        StartCoroutine("LoadNextLevel");
    }


    //IEnumerator LoadCurrentLevel()
    public void PlayAgain()
    {Debug.Log("here 2");
        //yield return new WaitForSeconds(loadDelay);
Debug.Log("here 3");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }


    IEnumerator LoadNextLevel()
    {Debug.Log("before");
        yield return new WaitForSeconds(loadDelay);
        Debug.Log("after");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        
        if(currentSceneIndex == SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }


    public void QuitApplication()
    {
        Application.Quit();
    }
}
