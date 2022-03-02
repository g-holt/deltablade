using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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


    public void DamageEnemy()
    {
        Debug.Log("Attack Damage: " + damage);
    }

}
