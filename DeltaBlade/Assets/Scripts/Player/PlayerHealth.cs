using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Animator animator;
    PlayerMovement playerMovement;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void ReduceHealth(float damage)
    {
        health -= damage;
        Debug.Log(health);

        if(health <= 0)
        {
            animator = playerMovement.GetAnimator();
            animator.SetBool("dead", true);
        }
    }

}
