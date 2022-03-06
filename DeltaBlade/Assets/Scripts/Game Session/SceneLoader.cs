using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    int currentSceneIndex;


    public void PlayAgain()
    {
        FindObjectOfType<WeaponCanvas>().ResetWeaponCanvasPersist();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void GameOver()
    {
        ///FindObjectOfType<UiPersist>().ResetScenePersist();
        FindObjectOfType<WeaponCanvas>().ResetWeaponCanvasPersist();
        
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }


    public void NextLevel()
    {
        StartCoroutine("LoadNextLevel");
    }


    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(loadDelay);

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
