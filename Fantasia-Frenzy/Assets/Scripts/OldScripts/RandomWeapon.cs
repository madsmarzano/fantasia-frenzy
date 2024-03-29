// Madison Marzano 03/15/2024

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class RandomWeapon : MonoBehaviour
{

    //public GameObject[] weapons; //array holding each possible upgrade weapon
    //public GameObject spawnPoint;
    private WeaponSwitching weapons;
    private Player player; 

    private int rand;

    private bool isTouchingBox;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapons = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponent<WeaponSwitching>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isTouchingBox) //checks if 'E' key is pressed and player is touching weapon box
        {
            GenerateWeapon();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            isTouchingBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTouchingBox)
        {
            isTouchingBox = false;
        }
    }

    private void GenerateWeapon()
    {
        //rand = Random.Range(0, weapons.Length);
        rand = Random.Range(0, weapons.transform.childCount);
        weapons.selectedWeapon = rand;

        //Instantiate(weapons[rand], spawnPoint.transform.position, transform.rotation, player.transform);
        //player.currentWeapon = weapons[rand];
    }
}