using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterWeaponSwitcher : MonoBehaviour
{
    [SerializeField] float swordDamage = 5f;
    [SerializeField] float axeDamage = 10f;

    public WeaponType currentWeapon; 

    public bool hasSword;
    public bool hasAxe;

    Animator animator;
    PlayerAttack playerAttack;
    PlayerMovement playerMovement;


    void Start() 
    {
        hasAxe = false;
        hasSword = false;

        playerMovement = GetComponentInParent<PlayerMovement>();
        playerAttack = GetComponentInParent<PlayerAttack>();

        SetCharacterActive(currentWeapon);    
    }


    public void SetCharacterWeapon(WeaponType weapon)
    {
        currentWeapon = weapon; 

        SetCharacterActive(weapon);
    }


    void OnChangeWeapon(InputValue value)
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame && hasSword)
        {
            //Sword
            currentWeapon = (WeaponType)1;
        }
        else if(Keyboard.current.digit2Key.wasPressedThisFrame && hasAxe)
        {   
            //Axe
            currentWeapon = (WeaponType)2;
        }

        SetCharacterActive(currentWeapon);
    }


    void SetCharacterActive(WeaponType currentWeapon)
    {
        WeaponType weaponTypeIndex = 0;

        foreach(Transform character in transform)
        {
            animator = character.gameObject.GetComponent<Animator>();
            
            if(weaponTypeIndex == currentWeapon)
            {
                SwapCharacter(character);
                DisarmedCheck(weaponTypeIndex);
                SetDamage(weaponTypeIndex);
            }
            else
            {
                character.gameObject.SetActive(false);
                animator.enabled = false;
            }
    
            weaponTypeIndex++;
        }
    }


    void SwapCharacter(Transform character)
    {
        //TODO: when switching mid jump the animation will walk in the air if moving or be idle instead of the jump animation
        character.gameObject.SetActive(true);
        animator.enabled = true;
        playerMovement.SetAnimator(animator);
        playerAttack.SetAnimator(animator);
    }


    void DisarmedCheck(WeaponType weaponTypeIndex)
    {
        if(weaponTypeIndex == 0)
        {
            playerMovement.isDisarmed = true;
            playerAttack.isDisarmed = true;
        }
        else
        {
            playerMovement.isDisarmed = false;
            playerAttack.isDisarmed = false;
        }
    }


    void SetDamage(WeaponType weapon)
    {
        if(weapon == (WeaponType)0)
        {
            //Disarmed
            playerAttack.SetDamage(0f);
        }
        else if(weapon == (WeaponType)1)
        {
            playerAttack.SetDamage(swordDamage);   
        }
        else if(weapon == (WeaponType)2) 
        {
            playerAttack.SetDamage(axeDamage);
        }
    }


    public void ResestCharacter()
    {
        hasAxe = false;
        hasSword = false;

        SetCharacterActive((WeaponType)0);
    }

}
