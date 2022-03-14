using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject leverPulled;
    [SerializeField] GameObject leverNotPulled;

    ExitDoor exitDoor;
    AudioSource audioSource;
    BoxCollider2D leverCollider;


    void Start() 
    {
        leverPulled.SetActive(false);
        leverNotPulled.SetActive(true);    

        exitDoor = FindObjectOfType<ExitDoor>();

        audioSource = GetComponent<AudioSource>();
        leverCollider = GetComponent<BoxCollider2D>();
    }


    //Called from OnPullLever() in PlayerMovement
    public void PullLever()
    {
        audioSource.Play();

        leverPulled.SetActive(true);
        leverNotPulled.SetActive(false);

        exitDoor.OpenDoor();
    }
    
}
