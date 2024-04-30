using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FallingCeiling : MonoBehaviour
{
    public float fallWait;
    public float destroyWait;
    public float distance;

    bool isFalling = false;
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.collider != null)
            {
                Debug.Log("Falling Ceiling Activated");
                StartCoroutine(Fall());
            }
        }
    }

    IEnumerator Fall()
    {
        isFalling = true;
        animator.Play("Warning");
        yield return new WaitForSeconds(fallWait);
        animator.Play("Falling");
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyWait);
    }
}
