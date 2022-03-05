using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;


    void OnEnable() 
    {

    }


    public void PlayAgain()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void NextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void QuitApplication()
    {
        Application.Quit();
    }
}
