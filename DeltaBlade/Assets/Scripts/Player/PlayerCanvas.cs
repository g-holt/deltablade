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

                if(livesImage.Count == 2)  //Will refactor over time; currently set up for convenience and as a working solution this currently considers PlayerHealth Text as a transform child 
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
        //Set all images active when game resets
        foreach(Transform image in playerCanvas.transform)
        {
            image.gameObject.SetActive(true);
        }
    }

}
