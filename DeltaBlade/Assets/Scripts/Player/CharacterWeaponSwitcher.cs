using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterWeaponSwitcher : MonoBehaviour
{
    public WeaponType currentWeapon; 
    
    public bool hasSword;
    public bool hasAxe;

    void Start() 
    {
        hasSword = false;
        hasAxe = false;
        SetCharacterActive(currentWeapon);    
    }


    public void SetCharacterWeapon(WeaponType weapon)
    {
        SetCharacterActive(weapon);
    }


    void OnChangeWeapon(InputValue value)
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame && hasSword)
        {
            currentWeapon = (WeaponType)1;
        }
        else if(Keyboard.current.digit2Key.wasPressedThisFrame && hasAxe)
        {
            currentWeapon = (WeaponType)2;
        }

        SetCharacterActive(currentWeapon);
    }


    void SetCharacterActive(WeaponType currentWeapon)
    {
        WeaponType weaponTypeIndex = 0;

        foreach(Transform character in transform)
        {
            if(weaponTypeIndex == currentWeapon)
            {
                character.gameObject.SetActive(true);
            }
            else
            {
                character.gameObject.SetActive(false);
            }
    
            weaponTypeIndex++;
        }
    }

}
