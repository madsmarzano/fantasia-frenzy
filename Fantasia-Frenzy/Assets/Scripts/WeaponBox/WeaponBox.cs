using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    private Animator animator;
    [SerializeField] WeaponValue weapon;
    private GameObject _WeaponHolder;
    [SerializeField] GameObject speechBubble;

    public bool isOpen = false;
    public bool boxActive = false;

    private int rand;

    private void Start()
    {
        animator = GetComponent<Animator>();
        speechBubble.SetActive(false);
        _WeaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && boxActive && !isOpen)
        {
            Open();
            GenerateWeapon();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Blink");
            speechBubble.SetActive(true);
            boxActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Idle");
            speechBubble.SetActive(false);
            boxActive = false;
        }
    }

    void Open()
    {
        if (!isOpen)
        {
            animator.Play("Open");
            speechBubble.SetActive(false);
            isOpen = true;
            //GetComponent<Collider2D>().enabled = false;
        }
    }

    private void GenerateWeapon()
    {
        Debug.Log("Generating Weapon");
        rand = Random.Range(1, _WeaponHolder.transform.childCount);
        while (rand == weapon.selected)
        {
            rand = Random.Range(1, _WeaponHolder.transform.childCount);
        }
        weapon.selected = rand;
    }
}
