using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WEAPON VALUE KEY
//  0 ---------> BASE GUN
//  1 ---------> AK 47
//  2 ---------> M4
//  3 ---------> MG
//  4 ---------> DEGAL
//  5 ---------> BOLT CASTER
//  6 ---------> RAIL GUN
//  7 ---------> SHOT GUN
//  8 ---------> MAGNUM
//  9 ---------> RPG-7
// 10 ---------> AWP

public class WeaponUI : MonoBehaviour
{
    [SerializeField] WeaponValue weapon;
    private int weaponDisplayed;

    private void Start()
    {
        ChangeWeaponDisplay();
    }

    private void Update()
    {
        if (weaponDisplayed != weapon.selected)
        {
            ChangeWeaponDisplay();
        }
    }

    private void ChangeWeaponDisplay()
    {
        int i = 0;
        foreach (Transform icon in transform)
        {
            if (i == weapon.selected)
                icon.gameObject.SetActive(true);
            else
                icon.gameObject.SetActive(false);
            i++;
        }
        weaponDisplayed = weapon.selected;
    }
}
