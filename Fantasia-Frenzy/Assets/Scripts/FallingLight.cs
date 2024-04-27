using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingLight : MonoBehaviour
{

    public float distance;
    public float fallWait;
    public float damage;
    private bool isActivated = false;
    private bool isFalling = false;
    [SerializeField] private PlayerHealthValue pHealth;
    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 startPos;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (!isActivated)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Falling Light Activated");
                StartCoroutine(Shake());
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Falling") && !isFalling)
        {
            Fall();
        }
    }

    IEnumerator Shake()
    {
        isActivated = true;
        animator.Play("Shake");
        yield return new WaitForSeconds(fallWait);
        animator.Play("Falling");
    }

    private void Fall()
    {
        isFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            pHealth.value -= damage;
            Destroy(gameObject);
        }
    }
}
