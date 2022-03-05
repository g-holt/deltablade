using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject leverOpen;
    [SerializeField] GameObject leverClosed;

    BoxCollider2D leverCollider;


    void Start() 
    {
        leverOpen.SetActive(false);
        leverClosed.SetActive(true);    

        leverCollider = GetComponent<BoxCollider2D>();
    }


    public void PullLever()
    {
        Debug.Log("here");
        leverOpen.SetActive(true);
        leverClosed.SetActive(false);
    }
}
