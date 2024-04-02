using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    private Rigidbody2D body;

    PlayerCollisionCheck playerCol;
    //private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<PlayerCollisionCheck>();
    }

    void Update()
    {

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); //moves player left and right 

        //check for spacebar input (JUMP)
        if (Input.GetKeyDown(KeyCode.Space) && playerCol.IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, height);
        //grounded = false;
    }

}
