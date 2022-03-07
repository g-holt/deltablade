using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{   
    List<Transform> livesImage = new List<Transform>();

    GameObject canvas;
    Canvas playerCanvas;
    PlayerHealth playerHealth;

    int imageIndex;


    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("PlayerCanvas");

        playerHealth = GetComponent<PlayerHealth>();
        playerCanvas = canvas.GetComponent<Canvas>();
    }


    void Start() 
    {
        playerHealth = GetComponent<PlayerHealth>();

        PopulateLivesList();    
    }


    public void PopulateLivesList()
    {
        foreach(Transform image in playerCanvas.transform)
        {
            if(image.gameObject.activeSelf)
            {
                livesImage.Add(image);
            }
        }
    }


    public void ReduceLives()
    {
        foreach(Transform image in playerCanvas.transform)
        {
            if(image.gameObject.activeSelf)
            {
                livesImage[imageIndex].gameObject.SetActive(false);

                if(livesImage.Count == 1) 
                { 
                    playerHealth.gameOver = true;
                    playerHealth.PlayerDeath();
                    return; 
                }

                return;
            }
        }
    }


    public void SetImagesActive()
    {
        foreach(Transform image in playerCanvas.transform)
        {
            image.gameObject.SetActive(true);
        }
    }

}
