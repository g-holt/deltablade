using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCanvas : MonoBehaviour
{
    [SerializeField] Canvas weaponCanvas;

    public bool hasSword;
    public bool hasAxe;


    // void Awake()
    // {
    //     int numScenePersists = FindObjectsOfType<WeaponCanvas>().Length;

    //     if(numScenePersists > 1)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }


    public void ResetWeaponCanvasPersist()
    {
        Destroy(gameObject);
    }


    void Start()
    {
        SetWeaponCanvasImage(false);
    }


    public void SetWeaponCanvasImage(bool state)
    {
        foreach(Transform weaponImage in weaponCanvas.transform)
        {
            weaponImage.gameObject.SetActive(state);
        }
    }


    public void SetWeaponCanvasImage(string name, bool state)
    {
        foreach(Transform weaponImage in weaponCanvas.transform)
        {
            if(weaponImage.name == name)
            {
                if(!weaponCanvas.enabled) { weaponCanvas.enabled = true; }
                weaponImage.gameObject.SetActive(state);
            }
        }
    }
}
