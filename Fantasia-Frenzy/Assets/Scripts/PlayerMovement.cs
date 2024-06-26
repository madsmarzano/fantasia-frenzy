using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;

    private Rigidbody2D body;
    private Animator animator;

    PlayerCollisionCheck playerCol;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<PlayerCollisionCheck>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); //moves player left and right 
    }

    private void Update()
    {
        //determine animation
        if (!playerCol.IsGrounded)
        {
            animator.Play("Jump");
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }

        //check for spacebar input (JUMP)
        if (Input.GetKeyDown(KeyCode.Space) && playerCol.IsGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, height);
        }

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
        }
    }

}
