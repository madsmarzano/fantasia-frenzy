using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LittleDemon : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float attackDistance;

    private bool isFinished = false;

    private Vector2 newPos;
    private Vector2 targetPos;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        GetDirection();
        //targetPos = new Vector2(transform.position.x * runDistance, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //GetDirection();

        //Vector2 targetPos = new Vector2 (transform.position.x * runDistance, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) < attackDistance && !isFinished)
        {
            GetDirection();
            Attack();
        }
    }

    private void GetDirection()
    {
        if (target.position.x < transform.position.x)
        {
            //enemy moves left
            direction = Vector2.left;
        }
        else if (target.position.x > transform.position.x)
        {
            //enemy moves right
            direction = Vector2.right;
        }
    }

    private void Attack()
    {
        while (Vector2.Distance(transform.position, target.position) < attackDistance)
        {
            rb.velocity = direction * speed;
        }
    }
}
