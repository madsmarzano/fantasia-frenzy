using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); //moves player left and right 

        //determine animation
        if (!playerCol.IsGrounded)
        {
            animator.Play("Jump");
        } else if (Input.GetAxis("Horizontal") != 0)
        {
            animator.Play("Walk");
        } else
        {
            animator.Play("Idle");
        }

        //check for spacebar input (JUMP)
        if (Input.GetKeyDown(KeyCode.Space) && playerCol.IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, height);
    }

}
