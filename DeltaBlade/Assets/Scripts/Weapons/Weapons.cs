using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;

    WeaponCanvas weaponCanvas;
    CharacterWeaponSwitcher weaponSwitcher;


    void Start() 
    {
        weaponCanvas = GetComponentInParent<WeaponCanvas>();
        weaponSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        //weaponCanvas = GetComponentInParent<WeaponCanvas>();

        if(weaponType == (WeaponType)1)
        {
            weaponCanvas.hasSword = true;
            weaponSwitcher.hasSword = true;
        }
        else if(weaponType == (WeaponType)2)
        {
            weaponCanvas.hasAxe = true;
            weaponSwitcher.hasAxe = true;
        }

        weaponSwitcher.SetCharacterWeapon(weaponType);
        weaponCanvas.SetWeaponCanvasImage(gameObject.name, true);

        Destroy(gameObject);
    }

}
