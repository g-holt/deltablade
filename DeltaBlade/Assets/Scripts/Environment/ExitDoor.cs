using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;

    CapsuleCollider2D doorCollider;

    bool isOpen;


    void Start() 
    {
        isOpen = false;

        closedDoor.SetActive(true);
        openDoor.SetActive(false);    

        doorCollider = GetComponent<CapsuleCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(isOpen && doorCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            isOpen = false;
            FindObjectOfType<SceneLoader>().NextLevel();
        }
    }


    public void OpenDoor()
    {   
        isOpen = true;

        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

}
