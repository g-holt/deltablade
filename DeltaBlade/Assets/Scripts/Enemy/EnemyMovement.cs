using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D playerFeetCollider;

    float moveDirection;
    bool isAttacking;
    bool wasFlipped;
    bool playerOnRight;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        playerFeetCollider = other.gameObject.GetComponent<BoxCollider2D>();

        if(other.gameObject.CompareTag("Player") && other.collider != playerFeetCollider)
        {
            FacePlayer(other.gameObject.transform);
            AttackPlayer(other.gameObject.transform);
        }    
    }


    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(wasFlipped)
            {
                wasFlipped = false;
                FlipSprite();
            }

            isAttacking = false;
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

        animator.SetBool("walk", true);
        rb.velocity = new Vector2(moveSpeed, 0f);
    }


    void AttackPlayer(Transform player)
    {
        if (player == null) { return; }

        animator.SetBool("walk", false);
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
            if (playerOnRight && moveDirection > 0) { return; }
            if (!playerOnRight && moveDirection < 0) { return; }

            wasFlipped = true;
            FlipSprite();
        }
    }


    void FlipSprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), 1f);
    }

}

/*

***** 1 *****
    
    moveDirection - Positive or Negative value == player and enemy facing the same direction; if 0 then they are facing each other
    Player and Enemy localScale.x should be the same base number 
        moveDirection = player.localScale.x + transform.localScale.x;
    

    Checking if the enemy is colliding with the back of the player if so don't flip;
        if (playerOnRight && moveDirection > 0) { return; }
        if (!playerOnRight && moveDirection < 0) { return; }
    

*/
