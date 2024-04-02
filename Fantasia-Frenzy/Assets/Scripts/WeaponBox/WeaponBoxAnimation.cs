using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WeaponBoxAnimation : MonoBehaviour
{

    private PlayerCollisionCheck playerCollider;
    private Animator animator;

    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionCheck>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerCollider.isTouchingBox && !isOpen)
        {
            Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Blink");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            animator.Play("Idle");
        }
    }

    void Open()
    {
        if (!isOpen)
        {
            animator.Play("Open");
            isOpen = true;
        }
    }
}
