using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponSwitcher : MonoBehaviour
{
    public int currentCharacter = 0; 

    CircleCollider2D mainPlayerCollider;


    void Start()
    {
        mainPlayerCollider = GetComponentInParent<CircleCollider2D>();
        SetCharacterActive(currentCharacter);
    }


    public void SetCharacterIndex(int index)
    {
        SetCharacterActive(index);
    }


    void SetCharacterActive(int currentCharacter)
    {
        int characterIndex = 0;

        foreach(Transform character in transform)
        {
            if(characterIndex == currentCharacter)
            {
                character.gameObject.SetActive(true);
            }
            else
            {
                character.gameObject.SetActive(false);
            }
            
            characterIndex++;
        }
    }

}
