using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] bool canAttack;

    Animator animator;


    void Start() 
    {
        animator = GetComponent<Animator>();    
    }


    void OnFire()
    {
        if(!canAttack){ return; }
        animator.SetTrigger("attack");
    }

}
