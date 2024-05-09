using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int currentWeapon = 0;

    [SerializeField] WeaponValue value;

    private void Start()
    {
        value.ResetValue();
        SelectWeapon(); //sets weapon to 0 at Start
    }

    private void Update()
    {

        // REJECT WEAPON
        if (Input.GetKeyDown(KeyCode.P) && value.selected != 0)
        {
            RejectWeapon();
        }

        if (value.current != value.selected)
        {
            SelectWeapon();
        }

    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == value.selected)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        value.current = value.selected;
    }

    void RejectWeapon()
    {
        value.selected = 0; //Return to Base Gun
        SelectWeapon();
    }

}
