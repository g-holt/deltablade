using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector2 movement;

    int moveDirection = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
    }


    void OnTriggerExit2D(Collider2D other) 
    {
            moveDirection *= -1;
    }


    void Move()
    {
        movement = new Vector2(moveSpeed * moveDirection, 0f);
        rb.velocity = movement;
    }


}
