using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public bool gameIsPaused;


    void Start() 
    {
        gameIsPaused = false;
        pauseMenu.SetActive(false);        
    }


    void Update() 
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(gameIsPaused)
            {
                ResumePlay();
            }
            else
            {
                PauseGame();
            }
        }    
    }


    public void ResumePlay()
    { 
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;
        gameIsPaused = false;
    }


    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


    public void QuitApplication()
    {
        Application.Quit();
    }

}
