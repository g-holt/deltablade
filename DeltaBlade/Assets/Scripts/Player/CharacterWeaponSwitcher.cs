using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponSwitcher : MonoBehaviour
{
    public WeaponType currentWeapon; 
    

    void Start() 
    {
        SetCharacterActive(currentWeapon);    
    }


    public void SetCharacterWeapon(WeaponType weapon)
    {
        SetCharacterActive(weapon);
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
            Debug.Log(weaponTypeIndex);
            weaponTypeIndex++;
        }
    }

}
