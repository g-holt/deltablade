using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] WeaponType weaponType;
    [SerializeField] float damage = 0f;
    
    AudioSource audioSource;
    WeaponCanvas weaponCanvas;
    PlayerAttack playerAttack;
    CharacterWeaponSwitcher weaponSwitcher;


    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        weaponCanvas = GetComponentInParent<WeaponCanvas>();
        
        playerAttack = FindObjectOfType<PlayerAttack>();
        weaponSwitcher = FindObjectOfType<CharacterWeaponSwitcher>();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {   
        if(!other.gameObject.CompareTag("Player")) { return; }

        HandleWeaponPickup();
    }


    void HandleWeaponPickup()
    {
        audioSource.PlayOneShot(audioSource.clip);

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
        
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        Destroy(gameObject, audioSource.clip.length);
    }


    float GetDamage()
    {
        return damage;
    }

}
