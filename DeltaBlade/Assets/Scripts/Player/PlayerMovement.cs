using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Vector2 playerVelocity;
    Vector2 jumpInput;
    Rigidbody2D rb;
    BoxCollider2D myFeetCollider;
    Animator animator;
    Attack attack;

    bool canJump;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        attack = GetComponentInChildren<Attack>();
    }

    
    void Update()
    {
        MovePlayer();
        FlipSprite();
    }


    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

            GroundCollision();
        }    

        // if(other.gameObject.CompareTag("Enemy"))
        // {
        //     attack.canDamage = true;
        // }
    }


    // void OnCollisionExit2D(Collision2D other) 
    // {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         attack.canDamage = false;
    //     }    
    // }


    void GroundCollision()
    {
        ToggleAnimation("jump", false);

        if(Mouse.current.rightButton.isPressed)
        {
            ShieldUp();
        }
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    void MovePlayer()
    {
        if(AnimationState("shield")) { return; }

        playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;    
        
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        ToggleAnimation("walk", hasHorizontalSpeed);
    }


    void OnJump(InputValue value)
    {
        /* 2 */
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if(!value.isPressed) { return; } 
        
        rb.velocity = new Vector2(0f, jumpSpeed);
        ToggleAnimation("jump", true);
    }


    void OnDefend(InputValue value)
    {
        
        //Setup as press and release in InputActions so method is called once when button is pressed and again when button released
        if(value.isPressed)
        {   
            ShieldUp();
        }
        if(!value.isPressed)
        {
            ToggleAnimation("shield", false);
        }
    }


    void ShieldUp()
    {
        if(!AnimationState("jump"))
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        ToggleAnimation("shield", true);
        ToggleAnimation("walk", false);
    }


    void ToggleAnimation(string animation, bool toggle)
    {   
        animator.SetBool(animation, toggle);
    }


    bool AnimationState(string animation)
    {
        return animator.GetBool(animation);
    }


    void FlipSprite()
    {
        /* 1 */
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        
        if(hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }


    public Animator GetAnimator()
    {
        return animator;
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


***** 2 *****
    Checking if the 2D Box Collider we have on the players feet is touching tiles with the 'Ground' Layer if not return so we can't 
    continue to jump; then confirming the Jump button is pressed, if not return;

    ~~~~ The myFeetCollider is set up so that the width is slightly smaller the width of our circle collider that represents the main
    portion of the player so when the player runs into walls which tiles are also set up with the 'Ground' Layer the circle collider 
    stops the player and does not allow the myFeetCollider to touch the tiles, which does not allow the player to jump and climb up 
    the walls;


*/


