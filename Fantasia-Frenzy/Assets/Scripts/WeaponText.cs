using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponText : MonoBehaviour
{
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

    [SerializeField] WeaponValue weapon;
    private TMP_Text weaponTxt;
    private int weaponDisplayed = 0;

    private void Start()
    {
        weaponTxt = GetComponent<TMP_Text>();
        PrintWeaponName();
    }

    private void Update()
    {
        if (weaponDisplayed != weapon.selected)
        {
            PrintWeaponName();
        }
    }
    void PrintWeaponName()
    {
        switch (weapon.selected)
        {
            case 0:
                weaponTxt.SetText("Base Gun");
                break;
            case 1:
                weaponTxt.SetText("AK 47");
                break;
            case 2:
                weaponTxt.SetText("M4");
                break;
            case 3:
                weaponTxt.SetText("Machinegun");
                break;
            case 4:
                weaponTxt.SetText("Degal");
                break;
            case 5:
                weaponTxt.SetText("Bolt Caster");
                break;
            case 6:
                weaponTxt.SetText("Rail Gun");
                break;
            case 7:
                weaponTxt.SetText("Shot Gun");
                break;
            case 8:
                weaponTxt.SetText("Magnum");
                break;
            case 9:
                weaponTxt.SetText("RPG-7");
                break;
            case 10:
                weaponTxt.SetText("AWP");
                break;
        }
        weaponDisplayed = weapon.selected;
    }
}
