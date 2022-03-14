using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;

    Enemy[] enemies;
    AudioSource audioSource;
    CapsuleCollider2D doorCollider;

    public bool isOpen;


    void Start() 
    {
        Time.timeScale = 1;

        isOpen = false;

        closedDoor.SetActive(true);
        openDoor.SetActive(false);    

        enemies = FindObjectsOfType<Enemy>();
        audioSource = GetComponent<AudioSource>();
        doorCollider = GetComponent<CapsuleCollider2D>();

        AudioListener.pause = false;
        audioSource.ignoreListenerPause = true;
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if(isOpen && doorCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            StopEnemies();

            isOpen = false;
            AudioListener.pause = true;
            audioSource.Play();

            FindObjectOfType<SceneLoader>().NextLevel();          
        }
    }


    public void StopEnemies()
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy == null) { return; }
            
            enemy.StopEnemyMovement();
        }
    }


    public void OpenDoor()
    {   
        isOpen = true;
        
        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

}
