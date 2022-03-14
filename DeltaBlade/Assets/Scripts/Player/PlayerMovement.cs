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

    public bool isDisarmed;
    public bool isAlive;

    bool isLeverPulled;


    void Start()
    {
        isAlive = true;
        
        lever = FindObjectOfType<Lever>();

        rb = GetComponent<Rigidbody2D>();
        
        playerHealth = GetComponent<PlayerHealth>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        if(!isAlive) { return; }

        MovePlayer();
        FlipSprite();
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(!isAlive) { return; }

        if(other.gameObject.CompareTag("Ground"))
        {
            if(!TouchingLayer(myFeetCollider, "Ground")) { return; }
            
            GroundCollision();
        }     

        if(other.gameObject.CompareTag("Hazards"))
        {
            playerHealth.SetHealthZero();
            playerHealth.PlayerDeath();
        }
    }


    void GroundCollision()
    {
        ToggleAnimation("jump", false);

        if(Mouse.current.rightButton.isPressed && !isDisarmed)
        {
            //Continues through jump and when on ground again if shield button is pressed and the player is not disarmed activate shield
            ShieldUp();
        }
    }


    void OnMove(InputValue value)
    {
        if(!isAlive) { return; } 

        moveInput = value.Get<Vector2>();
    }


    void MovePlayer()
    {
        if(!isDisarmed)
        {
            if(AnimationState("shield")) 
            {
                playerVelocity = new Vector2(0f, 0f);
                rb.velocity = playerVelocity;  
                return;
            } 
        }

        playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;    
        
        bool hasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        ToggleAnimation("walk", hasHorizontalSpeed);
    }


    void OnJump(InputValue value)
    {
        if(!isAlive) { return; } 
        if(!TouchingLayer(myFeetCollider, "Ground")) { return; }
        if(!value.isPressed) { return; } 
        
        rb.velocity = new Vector2(0f, jumpSpeed);
        ToggleAnimation("jump", true);
    }


    void OnDefend(InputValue value)
    {
        if(!isAlive) { return; }
        if(isDisarmed) { return; }

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
        if(AnimationState("jump")) { return; }
        
        rb.velocity = new Vector2(0f, 0f);
        
        ToggleAnimation("shield", true);
        ToggleAnimation("walk", false);
    }


    void OnPullLever()
    {
        if(!isAlive || isLeverPulled) { return; }

        if(!TouchingLayer(myBodyCollider, "Lever")) { return; }

        lever.PullLever();

        isLeverPulled = true;
    }


    void FlipSprite()
    {
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

