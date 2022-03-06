using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] [Range(0f, 1f)] float shieldPercent = .75f;

    Animator animator;
    DeathHandler deathHandler;
    PlayerMovement playerMovement;
    SceneLoader sceneLoader;

    public bool shieldUp;
    

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        animator = GetComponent<Animator>();
        deathHandler = GetComponent<DeathHandler>();
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
            PlayerDeath();
        }
    }


    public void PlayerDeath()
    {
        animator = playerMovement.GetAnimator();
        animator.SetBool("dead", true);
        playerMovement.enabled = false;

        StartCoroutine("HandleDeath");
    }


    IEnumerator HandleDeath()
    {

        yield return new WaitForSeconds(1f);
        
        deathHandler.GameOver();
        //sceneLoader.PlayAgain();
    }

}
