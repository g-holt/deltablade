using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;

    CharacterWeaponSwitcher weaponSwitcher;


    void Start() 
    {
        weaponSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        weaponSwitcher.SetCharacterWeapon(weaponType);
        Destroy(gameObject);
    }


}
