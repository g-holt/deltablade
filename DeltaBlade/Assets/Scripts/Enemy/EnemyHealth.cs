using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Animator animator;

    public bool canBeDamaged;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void ReduceEnemyHealth(float damage)
    {
        if(!canBeDamaged) { return; }

        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            animator.SetBool("dead", true);
        }
    }

}
