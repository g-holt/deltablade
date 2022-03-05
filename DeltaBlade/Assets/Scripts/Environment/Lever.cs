using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject leverPulled;
    [SerializeField] GameObject leverNotPulled;

    ExitDoor exitDoor;
    BoxCollider2D leverCollider;


    void Start() 
    {
        leverPulled.SetActive(false);
        leverNotPulled.SetActive(true);    

        exitDoor = FindObjectOfType<ExitDoor>();
        leverCollider = GetComponent<BoxCollider2D>();
    }


    public void PullLever()
    {
        leverPulled.SetActive(true);
        leverNotPulled.SetActive(false);

        exitDoor.OpenDoor();
    }
}
