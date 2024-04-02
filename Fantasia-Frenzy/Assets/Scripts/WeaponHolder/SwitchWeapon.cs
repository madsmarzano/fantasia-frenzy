using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private PlayerCollisionCheck playerCollider;

    public int selectedWeapon = 0;
    private int rand;
    private bool boxOpen = false;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionCheck>();

        SelectWeapon(); //sets weapon to 0 at Start
    }

    private void Update()
    {
        // REJECT WEAPON
        if (Input.GetKeyDown(KeyCode.Q) && selectedWeapon != 0)
        {
            RejectWeapon();
        }

        // INTERACTING WITH WEAPON BOX
        if (Input.GetKeyUp(KeyCode.E) && playerCollider.isTouchingBox && !boxOpen) //checks if 'E' key is pressed and player is touching weapon box
        {
            GenerateWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    //random weapon generator - called when interracting with Weapon Box
    private void GenerateWeapon()
    {
        rand = Random.Range(1, transform.childCount);
        while (rand == selectedWeapon)
        {
            rand = Random.Range(1, transform.childCount);
        }
        selectedWeapon = rand;
        boxOpen = true;
        SelectWeapon();
    }

    void RejectWeapon()
    {
        selectedWeapon = 0;
        SelectWeapon();
    }
}
