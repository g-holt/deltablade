using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    ScenePersist scenePersist;
    WeaponCanvas weaponCanvas;
    CharacterWeaponSwitcher characterSwitcher;

    int currentSceneIndex;


    public void PlayAgain()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;

        SceneManager.LoadScene(currentSceneIndex);
    }


    public void GameOver()
    {
        ResetGame();

        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }


    void ResetGame()
    {
        FindObjectOfType<PlayerCanvas>().SetImagesActive();
        FindObjectOfType<PlayerCanvas>().PopulateLivesList();
        FindObjectOfType<ScenePersist>().ResetUIPersist();
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

        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
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
