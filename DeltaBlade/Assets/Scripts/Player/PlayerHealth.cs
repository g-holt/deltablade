using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Animator animator;
    DeathHandler deathHandler;
    PlayerMovement playerMovement;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        deathHandler = GetComponent<DeathHandler>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void ReduceHealth(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            animator = playerMovement.GetAnimator();
            animator.SetBool("dead", true);
            playerMovement.enabled = false;
            
            StartCoroutine("HandleDeath");
        }
    }


    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f);
        deathHandler.GameOver();
    }

}
