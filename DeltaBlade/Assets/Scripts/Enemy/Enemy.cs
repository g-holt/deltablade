using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float attackDelay = 1f;

    Rigidbody2D rb;
    Transform player;
    Animator animator;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    BoxCollider2D playerFeetCollider;

    float moveDirection;
    bool isAttacking;
    bool wasFlipped;
    bool playerOnRight;
    bool canMove;


    void Start()
    {
        canMove = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();

        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    
    void Update()
    {
        if(!enemyHealth.isAlive) { return; }

        Move();
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        playerFeetCollider = other.gameObject.GetComponent<BoxCollider2D>();

        if(other.gameObject.CompareTag("Player") && other.collider != playerFeetCollider)
        {
            enemyHealth.canBeDamaged = true;
            player = other.gameObject.transform;

            animator.SetBool("walk", false);

            FacePlayer(player);
            AttackPlayer(player);
        }    
    }


    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();

            if(wasFlipped)
            {
                wasFlipped = false;
                FlipSprite();
            }

            isAttacking = false;
            enemyHealth.canBeDamaged = false;
            animator.SetBool("attack", false);
        }    
    }


    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")) { return; }

        moveSpeed = -moveSpeed;
        FlipSprite();
    }


    void Move()
    {
        if(isAttacking) { return; }

        if(!canMove)
        {
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("walk", false);
            return;
        }

        animator.SetBool("walk", true);
        rb.velocity = new Vector2(moveSpeed, 0f);
    }


    //Animation Event - Enemy Attack Animation
    void DelayAttack()
    {
        StartCoroutine("DelayNextAttack");
    }


    IEnumerator DelayNextAttack()
    {
        animator.SetBool("attack", false);

        yield return new WaitForSeconds(attackDelay);

        if(isAttacking)
        {
            AttackPlayer(player);
        }
    }


    void AttackPlayer(Transform player)
    {
        if (player == null) { return; }
        if(!canMove) { return; }

        animator.SetBool("attack", true);
    }


    void FacePlayer(Transform player)
    {
        if(player == null) { return; }

        moveDirection = player.localScale.x + transform.localScale.x;
        playerOnRight = player.position.x > transform.position.x; 

        isAttacking = true;
        rb.velocity = new Vector2(0f, 0f);

        if (moveDirection != 0)
        {
            //Checking which side of the player the enemy is colliding return if facing player, flip if not facing player
            if (playerOnRight && moveDirection > 0) { return; }
            if (!playerOnRight && moveDirection < 0) { return; }

            wasFlipped = true;
            FlipSprite();
        }
    }


    //Animation Event - Enemy Attack Animation
    void DamagePlayer()
    {
        if(!isAttacking) { return; }
        
        playerHealth.ReduceHealth(damage);
    }


    public void StopEnemyMovement()
    {
        canMove = false;

        rb.velocity = new Vector2(0f, 0f);
    }


    void FlipSprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), 1f);
    }

}
