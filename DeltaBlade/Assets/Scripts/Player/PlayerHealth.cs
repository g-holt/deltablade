using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] [Range(0f, 1f)] float shieldPercent = .75f;

    Animator animator;
    SceneLoader sceneLoader;
    DeathHandler deathHandler;
    PlayerCanvas playerCanvas;
    WeaponCanvas weaponCanvas;
    PlayerMovement playerMovement;

    public bool shieldUp;
    public bool gameOver;

    //int playerLives;
    

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }


    void Start()
    {   
        //playerLives = 3;

        sceneLoader = FindObjectOfType<SceneLoader>();

        animator = GetComponent<Animator>();
        deathHandler = GetComponent<DeathHandler>();
        playerCanvas = GetComponent<PlayerCanvas>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void ReduceHealth(float damage)
    {
        if(shieldUp)
        {
            damage = damage * shieldPercent;
        }

        health -= damage;

        if(health <= 0)
        {
            //playerLives--;

            playerCanvas.ReduceLives();
            PlayerDeath();
        }
    }


    public void PlayerDeath()
    {
        animator = playerMovement.GetAnimator();
        animator.SetBool("dead", true);
        playerMovement.enabled = false;

        if(gameOver)
        {
            StartCoroutine("HandleDeath");
        }
        else
        {Debug.Log("replay");
            //sceneLoader.PlayAgain();
            StartCoroutine("ResetLevel");
        }
    }


    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1f);

        sceneLoader.PlayAgain();
    }


    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f);

        deathHandler.GameOver();



        ///Destroy(gameObject);     
    }

}
