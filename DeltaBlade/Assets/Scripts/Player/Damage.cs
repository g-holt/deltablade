using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    Animator animator;


    void Start() 
    {
        animator = GetComponent<Animator>();    
    }


    void OnAttack()
    {
        animator.SetTrigger("attack");
    }

}
