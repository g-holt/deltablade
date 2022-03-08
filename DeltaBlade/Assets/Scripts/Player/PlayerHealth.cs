using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] AudioClip deathClip;
    [SerializeField] float health = 100f;
    [SerializeField] [Range(0f, 1f)] float shieldPercent = .75f;

    Animator animator;
    AudioClip audioClip;
    AudioSource audioSource;
    SceneLoader sceneLoader;
    Canvas playerHealthCanvas;
    DeathHandler deathHandler;
    PlayerAttack playerAttack;
    TextMeshProUGUI healthText;
    PlayerMovement playerMovement;
    PlayerCanvas playerCanvasScript;

    public bool shieldUp;
    public bool gameOver;
    

    void Start()
    {   
        sceneLoader = FindObjectOfType<SceneLoader>();

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        deathHandler = GetComponent<DeathHandler>();
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCanvasScript = GetComponent<PlayerCanvas>();
        healthText = GameObject.FindGameObjectWithTag("Player Health").GetComponent<TextMeshProUGUI>();

        healthText.text = health.ToString();
    }


    public void ReduceHealth(float damage)
    {
        if(shieldUp)
        {
            damage = damage * shieldPercent;
        }

        health -= damage;
        healthText.text = health.ToString();

        if(health <= 0)
        {
            playerMovement.isAlive = false;   
            playerAttack.isAlive = false;
            
            playerCanvasScript.ReduceLives();
            
            PlayerDeath();
        }
    }


    public void PlayerDeath()
    {
        animator = playerMovement.GetAnimator();
        animator.SetBool("dead", true);
        playerMovement.enabled = false;

        audioSource.PlayOneShot(deathClip);

        if(gameOver)
        {
            StartCoroutine("HandleDeath");
        }
        else
        {

            StartCoroutine("ResetLevel");
        }
    }


    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1f);

        sceneLoader.PlayAgain();
    }


    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f);

        deathHandler.GameOver();
    }


    public void SetHealth(float setHealth)
    {
        ReduceHealth(health);
    }

}
