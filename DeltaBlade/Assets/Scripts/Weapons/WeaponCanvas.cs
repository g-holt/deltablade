using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCanvas : MonoBehaviour
{
    Canvas weaponCanvas;

    public bool hasSword;
    public bool hasAxe;


    void Start()
    {
        weaponCanvas = GameObject.FindGameObjectWithTag("WeaponCanvas").GetComponent<Canvas>();
        SetWeaponCanvasImage(false);
    }


    public void SetWeaponCanvasImage(bool state)
    {
        hasAxe = false;
        hasSword = false;

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
