using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] GameObject closedDoor;
    [SerializeField] GameObject openDoor;

    SceneLoader sceneLoader;
    CapsuleCollider2D doorCollider;

    bool isOpen;


    void Start() 
    {
        isOpen = false;

        closedDoor.SetActive(true);
        openDoor.SetActive(false);    

        sceneLoader = FindObjectOfType<SceneLoader>();
        doorCollider = GetComponent<CapsuleCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {Debug.Log("here");
        if(isOpen && doorCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {Debug.Log("here 1");
            sceneLoader.PlayAgain();
        }
    }


    public void OpenDoor()
    {   
        isOpen = true;

        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

}
