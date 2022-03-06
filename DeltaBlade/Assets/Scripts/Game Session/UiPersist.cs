using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPersist : MonoBehaviour
{

    void Awake()
    {
        int numScenePersists = FindObjectsOfType<UiPersist>().Length;

        if(numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ResetUIPersist()
    {
        Destroy(gameObject);
    }

}
