using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;
    [SerializeField] float damage = 10f;

    CharacterWeaponSwitcher weaponSwitcher;


    void Start() 
    {
        weaponSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        weaponSwitcher.SetCharacterWeapon(weaponType);
    }


    public float GetDamage()
    {
        return damage;
    }


}
