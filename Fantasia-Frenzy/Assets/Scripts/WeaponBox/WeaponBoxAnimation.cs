using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WeaponBoxAnimation : MonoBehaviour
{

    private PlayerCollisionCheck playerCollider;
    private Animator animator;
    private SwitchWeapon weapon;
    private GameObject _WeaponHolder;

    public bool isOpen = false;
    public bool boxActive = false;

    private int rand;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionCheck>();
        weapon = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponent<SwitchWeapon>();
        _WeaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && boxActive && !isOpen)
        {
            Open();
            GenerateWeapon();
        }

        if (isOpen)
        {
            //DisableBox();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Blink");
            boxActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Idle");
            boxActive = false;
        }
    }

    void Open()
    {
        if (!isOpen)
        {
            animator.Play("Open");
            isOpen = true;
            //GetComponent<Collider2D>().enabled = false;
        }
    }

    private void GenerateWeapon()
    {
        Debug.Log("Generating Weapon");
        rand = Random.Range(1, transform.childCount);
        while (rand == weapon.selectedWeapon)
        {
            rand = Random.Range(1, _WeaponHolder.transform.childCount);
        }
        weapon.selectedWeapon = rand;
        //boxOpen = true;
        //SelectWeapon();
    }
}
