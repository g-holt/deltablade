using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 playerVelocity;

    bool hasHorizontalSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MovePlayer();
        FlipSprite();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    void MovePlayer()
    {
        playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;        
    }


    void FlipSprite()
    {
        /* 1 */
        hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        
        if(hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }



}


/*

***** 1 *****
    Our rb.velocity.x is either 5 or -5 since our moveInput is 1 or -1 multiplied by our moveSpeed of 5
    We're checking bool hasHorizontal speed(X Velocity) against Mathf.Epsilon which is the smallest value a float can have that isn't 0
    Since we're using Mathf.Abs() either way we move 5 or -5 will be 5 since it's checking the absolute value so as long as we have
    horizontal input from the play hasHorizontalSpeed will be true

    From that we're checking if hasHorizontalSpeed is true; if(hasHorizontalSpeed); if so then then were setting the localScale X to
    the ~SIGN~ of the Velocity(Direction we're moving 5 or -5); so moving left changes localScale to -1 and moving right changes localScale
    to 1 effectively flipping the sprite to the correct direction



*/


