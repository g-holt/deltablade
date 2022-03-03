using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Animator animator;
    Rigidbody2D rb;

    public bool canBeDamaged;
    public bool isAlive;

    void Start()
    {   
        isAlive = true;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void ReduceEnemyHealth(float damage)
    {
        if(!canBeDamaged) { return; }

        health -= damage;

        if(health <= 0)
        {
            isAlive = false;
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("dead", true);
        }
    }


    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
