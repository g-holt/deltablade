using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    UiPersist uiPersist;
    WeaponCanvas weaponCanvas;
    CharacterWeaponSwitcher characterSwitcher;

    int currentSceneIndex;


    // void Start() 
    // {
    //     uiPersist = FindObjectOfType<UiPersist>();
    //     weaponCanvas = FindObjectOfType<WeaponCanvas>();  
    //     characterSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();  
    // }


    public void PlayAgain()
    {
        //FindObjectOfType<WeaponCanvas>().SetWeaponCanvasImage(false);
        //FindObjectOfType<CharacterWeaponSwitcher>().ResestCharacter();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;

        SceneManager.LoadScene(currentSceneIndex);
    }


    public void GameOver()
    {
        //ResetGame();

        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }


    void ResetGame()
    {
        FindObjectOfType<PlayerCanvas>().SetImagesActive();
        //FindObjectOfType<UiPersist>().ResetUIPersist();
        // characterSwitcher.ResetCharacterSwitcherPersist();
        // weaponCanvas.ResetWeaponCanvasPersist();
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
