using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    Animator animator;
    EnemyHealth enemyHealth;

    public bool canDamage; 


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            canDamage = true;
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();     
        }    
    }


    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            canDamage = false;
        }    
    }


    void OnAttack()
    {
        animator.SetTrigger("attack");
        DamageEnemy();
    }


    public void DamageEnemy()
    {
        if(!canDamage) { return; }

        enemyHealth.ReduceEnemyHealth(damage);
    }


    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }

}
