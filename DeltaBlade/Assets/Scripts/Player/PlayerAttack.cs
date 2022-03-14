using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AudioClip weaponSwing;
    [SerializeField] AudioClip weaponHit;  
    
    Animator animator;
    EnemyHealth enemyHealth;
    AudioSource audioSource;

    public float damage = 0f;
    public bool canDamage; 
    public bool isDisarmed;
    public bool isAlive;


    void Start() 
    {
        isAlive = true;    

        audioSource = GetComponent<AudioSource>();
        
        audioSource.clip = weaponSwing;
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(isDisarmed || !isAlive) { return; }

            canDamage = true;
            audioSource.clip = weaponHit;
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();     
        }    
    }


    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            canDamage = false;
            audioSource.clip = weaponSwing;
        }    
    }


    void OnAttack()
    {
        if(isDisarmed || !isAlive) { return; }

        audioSource.PlayOneShot(audioSource.clip);
        
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


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

}
