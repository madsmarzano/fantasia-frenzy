using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;

    private Rigidbody2D rb;
    CapsuleCollider2D touchingCol;

    RaycastHit2D[] groundHits = new RaycastHit2D[5]; 

    public bool isTouchingBox = false;

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded { get { return _isGrounded; } private set { _isGrounded = value; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingCol = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WeaponBox"))
        {
            isTouchingBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WeaponBox"))
        {
            if (isTouchingBox)
            {
                isTouchingBox = false;
            }
        }
    }
}
