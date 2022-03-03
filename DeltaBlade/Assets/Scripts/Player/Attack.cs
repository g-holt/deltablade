using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    Animator animator;
    EnemyHealth enemyHealth;

    public bool canDamage; 


    void Start() 
    {
        animator = GetComponent<Animator>();    
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }


    void OnAttack()
    {
        animator.SetTrigger("attack");
    }


    public void DamageEnemy()
    {
        enemyHealth.ReduceEnemyHealth(damage);
    }

}
