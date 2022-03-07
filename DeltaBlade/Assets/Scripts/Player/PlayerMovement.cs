using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;                                          

    Vector2 moveInput;
    Vector2 playerVelocity;
    Lever lever;
    Rigidbody2D rb;
    Animator animator;
    PlayerHealth playerHealth;
    BoxCollider2D myFeetCollider;
    CapsuleCollider2D myBodyCollider;


    void Start()
    {
        lever = FindObjectOfType<Lever>();

        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        MovePlayer();
        FlipSprite();
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(!TouchingLayer(myFeetCollider, "Ground")) { return; }
            
            GroundCollision();
        }     

        if(other.gameObject.CompareTag("Hazards"))
        {
            playerHealth.PlayerDeath();
        }
    }


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
        if(AnimationState("shield")) 
        { 
            playerVelocity = new Vector2(0f, 0f);
            rb.velocity = playerVelocity;  
            return; 
        }

        playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;    
        
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        ToggleAnimation("walk", hasHorizontalSpeed);
    }


    void OnJump(InputValue value)
    {
        /* 2 */
        if(!TouchingLayer(myFeetCollider, "Ground")) { return; }
        if(!value.isPressed) { return; } 
        
        rb.velocity = new Vector2(0f, jumpSpeed);
        ToggleAnimation("jump", true);
    }


    void OnDefend(InputValue value)
    {
        //Setup as press and release in InputActions so method is called once when button is pressed and again when button released
        if(value.isPressed)
        {   
            playerHealth.shieldUp = true;

            ShieldUp();
        }
        if(!value.isPressed)
        {
            playerHealth.shieldUp = false;

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


    void OnPullLever()
    {
        if(!TouchingLayer(myBodyCollider, "Lever")) { return; }

        lever.PullLever();
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


    void ToggleAnimation(string animation, bool toggle)
    {   
        animator.SetBool(animation, toggle);
    }


    bool AnimationState(string animation)
    {
        return animator.GetBool(animation);
    }


    bool TouchingLayer(Collider2D collider, string layer)
    {
        if(collider.IsTouchingLayers(LayerMask.GetMask(layer)))
        {
            return true;
        }

        return false;
    }


    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
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


