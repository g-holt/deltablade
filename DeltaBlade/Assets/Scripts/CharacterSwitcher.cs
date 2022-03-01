using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public int currentCharacter = 0; 


    void Start()
    {
        SetCharacterActive();
    }


    void Update()
    {
        
    }


    void SetCharacterActive()
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
