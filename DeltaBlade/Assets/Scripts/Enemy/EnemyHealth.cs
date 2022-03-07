using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D enemyBodyCollider;

    public bool isAlive;
    public bool canBeDamaged;


    void Start()
    {   
        isAlive = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyBodyCollider = GetComponent<CapsuleCollider2D>();
    }


    public void ReduceEnemyHealth(float damage)
    {
        if(!canBeDamaged) { return; }

        health -= damage;

        if(health <= 0)
        {
            isAlive = false;
            rb.velocity = new Vector2(0f, 0f);
            enemyBodyCollider.enabled = false;

            animator.SetBool("dead", true);
        }
    }


    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
