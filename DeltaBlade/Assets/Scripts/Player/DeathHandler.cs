using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    int currentSceneIndex;


    void Start()
    {
        gameOverCanvas.enabled = false;        
    }

 
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
    }

}
