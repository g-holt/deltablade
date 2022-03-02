using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;

    Canvas canvas;
    CharacterWeaponSwitcher weaponSwitcher;


    void Start() 
    {
        canvas = FindObjectOfType<Canvas>();
        weaponSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();

        SetWeaponCanvasImage(gameObject.name, false);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(weaponType == (WeaponType)1)
        {
            weaponSwitcher.hasSword = true;
        }
        else if(weaponType == (WeaponType)2)
        {
            weaponSwitcher.hasAxe = true;
        }
        
        weaponSwitcher.SetCharacterWeapon(weaponType);

        SetWeaponCanvasImage(gameObject.name, true);
        Destroy(gameObject);
    }


    public void SetWeaponCanvasImage(string name, bool state)
    {
        foreach(Transform weaponImage in canvas.transform)
        {
            if(weaponImage.name == name)
            {
                weaponImage.gameObject.SetActive(state);
            }
        }
    }

}
