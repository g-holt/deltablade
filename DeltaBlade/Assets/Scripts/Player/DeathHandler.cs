using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    
    Canvas gameOverCanvas;
    GameObject gameOverGameObj;

    int currentSceneIndex;


    void Start()
    {
        gameOverGameObj = GameObject.FindGameObjectWithTag("GameOverCanvas");

        gameOverCanvas = gameOverGameObj.gameObject.GetComponent<Canvas>();
        
        gameOverCanvas.enabled = false;        
    }

 
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
    }

}
